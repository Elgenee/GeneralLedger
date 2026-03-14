using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralLedger.Persistence.Services
{
    public class InventoryAdjustmentServices : IInventoryAdjustmentServices
    {
        public InventoryAdjustment Add(InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<InventoryAdjustmentDetail> inventoryAdjustmentDetailList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                // Add InventoryAdjustmentDetails and Stocks
                AddInventoryAdjustmentDetails(inventoryAdjustment, inventoryAdjustmentDetailList, unitOfWork);

                // Build Description
                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in inventoryAdjustmentDetailList)
                {
                    var product = detail.Product;
                    var size = product?.ProductSize;
                    var color = product?.ProductColor;
                    var prodType = product?.ProductType;

                    productDetailsBuilder.AppendLine("# " +
                        (product?.strProductName ?? string.Empty) +
                        "; Size: " + (size?.strName ?? string.Empty) +
                        "; Color: " + (color?.strName ?? string.Empty) +
                        "; ProdType: " + (prodType?.strName ?? string.Empty) +
                        (!string.IsNullOrEmpty(product?.strPR) ? "; PR: " + product.strPR : "") +
                        "; Qty: " + detail.Quantity.ToString());
                }

                inventoryAdjustment.Description = productDetailsBuilder.ToString();

                // Add InventoryAdjustment to repository
                unitOfWork.InventoryAdjustment.Add(inventoryAdjustment);

                // Update remaining count for products
                UpdateRemainingCount(unitOfWork, inventoryAdjustment, inventoryAdjustmentDetailList);

                //// Add GL Transaction
                //AddGLTran(unitOfWork, inventoryAdjustment, tblGLTranDetail, UseDefaultEntry);

                //// Add Inventory GL Transaction
                //AddGLTranInventory(unitOfWork, inventoryAdjustment);

                unitOfWork.Complete();
                return inventoryAdjustment;
            }
        }

        private void AddInventoryAdjustmentDetails(InventoryAdjustment inventoryAdjustment, List<InventoryAdjustmentDetail> inventoryAdjustmentDetailList, UnitOfWork unitOfWork)
        {
            foreach (var item in inventoryAdjustmentDetailList)
            {
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(item.ProductId ?? 0);

                inventoryAdjustment.InventoryAdjustmentDetails.Add(new InventoryAdjustmentDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                    Product = product
                });

                if (inventoryAdjustment.InventoryAdjustmentTypeId == 2)
                {
                    inventoryAdjustment.Stocks.Add(new Stock
                    {
                        ProductId = item.ProductId,
                        QuantityIn = 0,
                        QuantityOut = item.Quantity,
                        StockTransactionTypeID = 4002, // Use appropriate transaction type for adjustment
                        InventoryAdjustmentID = inventoryAdjustment.Id,
                        Product = product,
                        TransactionDate = inventoryAdjustment.TransactionDate
                    });
                }
                else
                {
                    inventoryAdjustment.Stocks.Add(new Stock
                    {
                        ProductId = item.ProductId,
                        QuantityIn = item.Quantity,
                        QuantityOut = 0,
                        StockTransactionTypeID = 4002, // Use appropriate transaction type for adjustment
                        InventoryAdjustmentID = inventoryAdjustment.Id,
                        Product = product,
                        TransactionDate = inventoryAdjustment.TransactionDate
                    });
                }

           

            }
        }

        public void UpdateRemainingCount(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment, List<InventoryAdjustmentDetail> inventoryAdjustmentDetail)
        {
            foreach (var detail in inventoryAdjustmentDetail)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
                var product = unitOfWork.Products.Get(productID);
                var newStocks = inventoryAdjustment.Stocks.ToList();
                product.intRemainingCount = GetTotalRemainingStock(unitOfWork, productID, newStocks);
            }
        }

        public int GetTotalRemainingStock(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != System.Data.Entity.EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId));
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        }

        private void AddGLTran(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            if (UseDefaultEntry)
            {
                AddDefaultGLTran(unitOfWork, inventoryAdjustment);
            }
            else
            {
                AddCustomGLTran(unitOfWork, inventoryAdjustment, tblGLTranDetail);
            }
        }

        private void AddDefaultGLTran(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment)
        {
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, inventoryAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0)),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, inventoryAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0), 0),
            };

            AddGLTranHeader(unitOfWork, inventoryAdjustment, gLTranDetail);
        }

        private tblGLTranDetail CreateGLTranDetail(int intIDMasCoa, int intIDMasCoaSub, decimal curCredit, decimal curDebit)
        {
            return new tblGLTranDetail
            {
                intIDMasCoa = intIDMasCoa,
                intIDMasCoaSub = intIDMasCoaSub,
                curCredit = curCredit,
                curDebit = curDebit
            };
        }

        private void AddGLTranHeader(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> gLTranDetail)
        {
            StringBuilder productDetailsBuilder = new StringBuilder();
            productDetailsBuilder.AppendLine(inventoryAdjustment.Description);

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 12, // Use appropriate book type for inventory adjustment
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = inventoryAdjustment.TransactionDate,
                strTransactionCode = inventoryAdjustment.TransactionNo,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                // Link to InventoryAdjustment if needed
                // intIdInventoryAdjustment = inventoryAdjustment.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        private void AddCustomGLTran(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> tblGLTranDetail)
        {
            StringBuilder productDetailsBuilder = new StringBuilder();
            productDetailsBuilder.AppendLine(inventoryAdjustment.Description);

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 12, // Use appropriate book type for inventory adjustment
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = inventoryAdjustment.TransactionDate,
                strTransactionCode = inventoryAdjustment.TransactionNo,
                datInsertedDate = DateTime.Now,
                blnUseDefaultEntry = false
            };

            foreach (var item in tblGLTranDetail)
            {
                gLTranHeader.tblGLTranDetails.Add(new tblGLTranDetail
                {
                    intIDMasCoa = item.intIDMasCoa,
                    intIDMasCoaSub = item.intIDMasCoaSub,
                    curCredit = item.curCredit,
                    curDebit = item.curDebit
                });
            }
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        public void AddGLTranInventory(UnitOfWork unitOfWork, InventoryAdjustment inventoryAdjustment)
        {
            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

            var totalAmount = inventoryAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0);

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, 0, totalAmount),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, totalAmount, 0),
            };

            StringBuilder productDetailsBuilder = new StringBuilder();
            productDetailsBuilder.AppendLine(inventoryAdjustment.Description);

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strTransactionCode = inventoryAdjustment.TransactionNo,
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = inventoryAdjustment.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        public InventoryAdjustment Update(
            InventoryAdjustment updatedAdjustment,
            List<tblGLTranDetail> updatedTblGLTranDetail,
            bool UseDefaultEntry,
            List<InventoryAdjustmentDetail> updatedAdjustmentDetailsList)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
                {
                    // 1. Update adjustment details and associated stock records
                    UpdateInventoryAdjustmentDetails(updatedAdjustment, updatedAdjustmentDetailsList, unitOfWork);

                    // 2. Update main InventoryAdjustment record in the repository
                    var adj = unitOfWork.InventoryAdjustment.Get(updatedAdjustment.Id);
                    adj.TransactionNo = updatedAdjustment.TransactionNo;
                    adj.InventoryAdjustmentTypeId = updatedAdjustment.InventoryAdjustmentTypeId;
                    adj.TransactionDate = updatedAdjustment.TransactionDate;

                    // Build Description
                    StringBuilder productDetailsBuilder = new StringBuilder();
                    foreach (var detail in updatedAdjustmentDetailsList)
                    {
                        var product = detail.Product;
                        var size = product?.ProductSize;
                        var color = product?.ProductColor;
                        var prodType = product?.ProductType;

                        productDetailsBuilder.AppendLine("# " +
                            (product?.strProductName ?? string.Empty) +
                            "; Size: " + (size?.strName ?? string.Empty) +
                            "; Color: " + (color?.strName ?? string.Empty) +
                            "; ProdType: " + (prodType?.strName ?? string.Empty) +
                            (!string.IsNullOrEmpty(product?.strPR) ? "; PR: " + product.strPR : "") +
                            "; Qty: " + detail.Quantity.ToString());
                    }
                    adj.Description = productDetailsBuilder.ToString();

                    adj.InventoryAdjustmentDetails = updatedAdjustment.InventoryAdjustmentDetails;
                    adj.Stocks = updatedAdjustment.Stocks;
                    updatedAdjustment.Description = adj.Description;

                    // 3. Update remaining stock count for products in adjustment details
                    UpdateRemainingCount(unitOfWork, updatedAdjustment, updatedAdjustmentDetailsList);

                    // 4. Update general ledger transaction records
                    //UpdateGLTran(unitOfWork, updatedAdjustment, updatedTblGLTranDetail, UseDefaultEntry);
                    //UpdateGLTranInventory(unitOfWork, updatedAdjustment);

                    // 5. Commit changes to the database
                    unitOfWork.Complete();

                    return updatedAdjustment;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateInventoryAdjustmentDetails(InventoryAdjustment updatedAdjustment, List<InventoryAdjustmentDetail> updatedAdjustmentDetailsList, UnitOfWork unitOfWork)
        {
            // Delete existing adjustment details and stock records
            foreach (var existingDetail in updatedAdjustment.InventoryAdjustmentDetails.ToList())
            {
                var adjustmentDetailExist = unitOfWork.InventoryAdjustmentDetails.Get(existingDetail.Id);
                if (adjustmentDetailExist != null)
                    unitOfWork.InventoryAdjustmentDetails.Remove(adjustmentDetailExist);

                var existingStock = unitOfWork.Stock
                    .Find(s => s.ProductId == existingDetail.ProductId && s.InventoryAdjustmentID == existingDetail.InventoryAdjustmentId)
                    .FirstOrDefault();
                if (existingStock != null)
                    unitOfWork.Stock.Remove(existingStock);

                int productID = (existingDetail.ProductId.HasValue) ? existingDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.Get(productID);
                var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId).ToList();
                existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != System.Data.Entity.EntityState.Deleted).ToList();
                var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
                product.intRemainingCount = totalStocks;
            }
            updatedAdjustment.InventoryAdjustmentDetails.Clear();
            updatedAdjustment.Stocks.Clear();

            // Add new adjustment details and stock records
            foreach (var updatedDetail in updatedAdjustmentDetailsList)
            {
                int productID = (updatedDetail.ProductId.HasValue) ? updatedDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(productID);

                updatedAdjustment.InventoryAdjustmentDetails.Add(new InventoryAdjustmentDetail
                {
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice,
                    Product = product
                });

                if (updatedAdjustment.InventoryAdjustmentTypeId == 2)
                {
                    updatedAdjustment.Stocks.Add(new Stock
                    {
                        ProductId = updatedDetail.ProductId,
                        QuantityIn = 0,
                        QuantityOut = updatedDetail.Quantity,
                        StockTransactionTypeID = 4002,
                        InventoryAdjustmentID = updatedAdjustment.Id,
                        Product = product,
                        TransactionDate = updatedAdjustment.TransactionDate
                    });
                }
                else
                {
                    updatedAdjustment.Stocks.Add(new Stock
                    {
                        ProductId = updatedDetail.ProductId,
                        QuantityIn = updatedDetail.Quantity,
                        QuantityOut = 0,
                        StockTransactionTypeID = 4002,
                        InventoryAdjustmentID = updatedAdjustment.Id,
                        Product = product,
                        TransactionDate = updatedAdjustment.TransactionDate
                    });
                }
            }
        }

        private void UpdateGLTran(
            UnitOfWork unitOfWork,
            InventoryAdjustment updatedAdjustment,
            List<tblGLTranDetail> tblGLTranDetail,
            bool UseDefaultEntry)
        {
            // Delete existing GLTran entries for the adjustment
            var existingGLTranHeader = unitOfWork.GLTran
                .Find(h => h.intIdAccountReceivableAdjustment == updatedAdjustment.Id && h.intIDGLBookType == 12)
                .SingleOrDefault();
            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);
                if (existingGLTranDetail != null)
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
            }

            if (existingGLTranHeader != null)
            {
                existingGLTranHeader.datBatchDate = updatedAdjustment.TransactionDate;

                StringBuilder productDetailsBuilder = new StringBuilder();
                productDetailsBuilder.AppendLine(updatedAdjustment.Description);

                existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
                existingGLTranHeader.blnUseDefaultEntry = UseDefaultEntry;
                existingGLTranHeader.strTransactionCode = updatedAdjustment.TransactionNo;

                // Re-insert the GLTran entries for the adjustment
                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

                    var gLTranDetail = new List<tblGLTranDetail>
            {
                new tblGLTranDetail
                {
                    intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                    intIDMasCoaSub = journalEntry1.ID,
                    curCredit = 0,
                    curDebit = updatedAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0),
                    intIDGLTranHeader = existingGLTranHeader.ID
                },
                new tblGLTranDetail
                {
                    intIDMasCoa = (int)journalEntry2.intIDMasCOA,
                    intIDMasCoaSub = journalEntry2.ID,
                    curCredit = updatedAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0),
                    curDebit = 0,
                    intIDGLTranHeader = existingGLTranHeader.ID
                }
            };

                    unitOfWork.GLTranDetail.AddRange(gLTranDetail);

                    existingGLTranHeader.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
                    existingGLTranHeader.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);
                }
                else
                {
                    foreach (var item in tblGLTranDetail)
                    {
                        existingGLTranHeader.tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub,
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = existingGLTranHeader.ID
                        });
                    }

                    unitOfWork.GLTranDetail.AddRange(existingGLTranHeader.tblGLTranDetails);
                    existingGLTranHeader.curDebitAmount = existingGLTranHeader.tblGLTranDetails.Sum(c => c.curDebit);
                    existingGLTranHeader.curCreditAmount = existingGLTranHeader.tblGLTranDetails.Sum(c => c.curCredit);
                }
            }
        }

        private void UpdateGLTranInventory(UnitOfWork unitOfWork, InventoryAdjustment updatedAdjustment)
        {
            // Delete existing GLTran entries for the adjustment (Inventory BookType)
            var existingGLTranHeader = unitOfWork.GLTran
                .Find(h => h.intIdAccountReceivableAdjustment == updatedAdjustment.Id && h.intIDGLBookType == 1011)
                .SingleOrDefault();
            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);
                if (existingGLTranDetail != null)
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
            }

            if (existingGLTranHeader != null)
            {
                existingGLTranHeader.datBatchDate = updatedAdjustment.TransactionDate;

                StringBuilder productDetailsBuilder = new StringBuilder();
                productDetailsBuilder.AppendLine(updatedAdjustment.Description);

                existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
                existingGLTranHeader.strTransactionCode = updatedAdjustment.TransactionNo;
                existingGLTranHeader.blnUseDefaultEntry = true;

                // Re-insert the GLTran entries for the adjustment
                var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
                var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                var totalAmount = updatedAdjustment.InventoryAdjustmentDetails.Sum(d => d.TotalPrice ?? 0);

                var gLTranDetail = new List<tblGLTranDetail>
        {
            new tblGLTranDetail
            {
                intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                intIDMasCoaSub = journalEntry3.ID,
                curCredit = 0,
                curDebit = totalAmount,
                intIDGLTranHeader = existingGLTranHeader.ID
            },
            new tblGLTranDetail
            {
                intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                intIDMasCoaSub = journalEntry1.ID,
                curCredit = totalAmount,
                curDebit = 0,
                intIDGLTranHeader = existingGLTranHeader.ID
            }
        };

                unitOfWork.GLTranDetail.AddRange(gLTranDetail);

                existingGLTranHeader.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
                existingGLTranHeader.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);
            }
        }


        public void Remove(InventoryAdjustment inventoryAdjustment, List<InventoryAdjustmentDetail> inventoryAdjustmentDetailList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                // Retrieve the full InventoryAdjustment entity (with details and GL entries)
                var resultAdjustment = unitOfWork.InventoryAdjustment
                    .Find(a => a.Id == inventoryAdjustment.Id)
                    .SingleOrDefault();

                if (resultAdjustment == null)
                {
                    throw new Exception("Inventory Adjustment not found!");
                }

                RemoveInventoryAdjustmentDetails(unitOfWork, inventoryAdjustmentDetailList);
                //RemoveGLTran(unitOfWork, resultAdjustment);
                unitOfWork.InventoryAdjustment.Remove(resultAdjustment);

                unitOfWork.Complete();
            }
        }

        private void RemoveInventoryAdjustmentDetails(UnitOfWork unitOfWork, List<InventoryAdjustmentDetail> inventoryAdjustmentDetailList)
        {
            foreach (var detail in inventoryAdjustmentDetailList)
            {
                RemoveInventoryAdjustmentDetail(unitOfWork, detail);
                UpdateRemainingStock(unitOfWork, detail);
            }
            inventoryAdjustmentDetailList.Clear();
        }

        private void RemoveInventoryAdjustmentDetail(UnitOfWork unitOfWork, InventoryAdjustmentDetail detail)
        {
            var adjustmentDetailExist = unitOfWork.InventoryAdjustmentDetails.Get(detail.Id);
            if (adjustmentDetailExist != null)
            {
                unitOfWork.InventoryAdjustmentDetails.Remove(adjustmentDetailExist);
            }

            var existingStock = unitOfWork.Stock
                .Find(s => s.ProductId == detail.ProductId && s.InventoryAdjustmentID == detail.InventoryAdjustmentId)
                .FirstOrDefault();
            if (existingStock != null)
            {
                unitOfWork.Stock.Remove(existingStock);
            }
        }

        private void UpdateRemainingStock(UnitOfWork unitOfWork, InventoryAdjustmentDetail detail)
        {
            int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
            var product = unitOfWork.Products.Get(productID);
            var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId).ToList();
            existingStockList = existingStockList
                .Where(stock => unitOfWork.GetEntityState(stock) != System.Data.Entity.EntityState.Deleted)
                .ToList();
            var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
            product.intRemainingCount = totalStocks;
        }

        private void RemoveGLTran(UnitOfWork unitOfWork, InventoryAdjustment adjustment)
        {
            // Remove all GLTranHeaders and their details linked to this adjustment
            var glTranHeaders = unitOfWork.GLTran
                .Find(h => h.intIdAccountReceivableAdjustment == adjustment.Id)
                .ToList();

            foreach (var header in glTranHeaders)
            {
                var glTranDetails = unitOfWork.GLTranDetail
                    .Find(d => d.intIDGLTranHeader == header.ID)
                    .ToList();
                unitOfWork.GLTranDetail.RemoveRange(glTranDetails);
            }
            unitOfWork.GLTran.RemoveRange(glTranHeaders);
        }

        public List<InventoryAdjustment> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.InventoryAdjustment.GetAll().ToList();
            }
        }

        public List<InventoryAdjustment> GetInventoryAdjustmentWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<InventoryAdjustment> GetInventoryAdjustmentWithInventoryAdjustmentType(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.InventoryAdjustment.GetInventoryAdjustmentWithInventoryAdjustmentType(criteria).ToList();
            }
        }


        // Implement other methods (GetAll, Update, Remove, etc.) as needed, following the same mapping logic.
    }
}