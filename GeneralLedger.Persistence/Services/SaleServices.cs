using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class SaleServices : ISaleServices
    {
        //public Sale Add(Sale sale , List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        //{
        //    using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
        //    {
        //       unitOfWork.Sale.Add(sale);

        //        var salesCustomerLedger = new SalesCustomerLedger { 
        //         intIdSales = sale.Id,
        //         intIdCustomer = sale.intIdCustomer,
        //         intIdSalesCustomerLedgerTransctionType = 1,
        //         TotalAmount = sale.Total,
        //         TransactionDate = sale.TransactionDate,
        //         TransactionNo = sale.TRANo,
        //         DateInserted = DateTime.Now
        //        };

        //        unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);

        //        if (UseDefaultEntry)
        //        {
        //            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
        //            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
        //            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
        //            var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
        //            var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

        //            var gLTranDetail = new List<tblGLTranDetail>
        //            {
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry1.ID,
        //                     curCredit = 0,
        //                     curDebit = sale.Total 
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry2.ID,
        //                     curCredit = sale.SOPAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry3.ID,
        //                     curCredit = sale.COMMAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry4.ID,
        //                     curCredit = sale.CFAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry5.ID,
        //                     curCredit = sale.Total - (sale.COMMAmount + sale.SOPAmount + sale.CFAmount),
        //                     curDebit = 0
        //                 }
        //            };

        //            var gLTranHeader = new tblGLTranHeader
        //            {
        //                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
        //                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
        //                intIDGLBookType = 6,
        //                //strTransactionCode = "SAL-" + sale.Id,
        //                strDescription = sale.Description,
        //                datBatchDate = sale.TransactionDate,
        //                datInsertedDate = DateTime.Now,
        //                tblGLTranDetails = gLTranDetail,
        //                intIdSales = sale.Id,
        //                blnUseDefaultEntry = UseDefaultEntry
        //            };

        //            unitOfWork.GLTran.Add(gLTranHeader);
        //        }
        //        else
        //        {
        //            var gLTranHeader = new tblGLTranHeader
        //            {
        //                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
        //                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
        //                intIDGLBookType = 6,
        //                //strTransactionCode = "SAL-" + sale.Id,
        //                strDescription = sale.Description,
        //                datBatchDate = sale.TransactionDate,
        //                datInsertedDate = DateTime.Now,
        //                //tblGLTranDetails = tblGLTranDetail,
        //                intIdSales = sale.Id,
        //                blnUseDefaultEntry = UseDefaultEntry
        //            };

        //            foreach (var item in tblGLTranDetail)
        //            {
        //                gLTranHeader.tblGLTranDetails.Add(new tblGLTranDetail
        //                {
        //                    intIDMasCoa = item.intIDMasCoa,
        //                    intIDMasCoaSub = item.intIDMasCoaSub,
        //                    curCredit = item.curCredit,
        //                    curDebit = item.curDebit

        //                });
        //            }
        //            unitOfWork.GLTran.Add(gLTranHeader);
        //        }


        //        //var result = unitOfWork.GLTran.GetGLEntryById(9030);
        //        unitOfWork.Complete();
        //        return sale;
        //    }
        //}

        public Sale Add(Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool useDefaultEntry, List<SalesDetail> saleDetailsList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                AddSaleDetails(sale, saleDetailsList, unitOfWork);

                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in saleDetailsList)
                {
                    var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                    var size = product.ProductSize; // Assuming Product has a Size property
                    var color = product.ProductColor; // Assuming Product has a Color property

                    productDetailsBuilder.AppendLine("# " + product.strProductName +
                                                     "; Size: " + size.strName +
                                                     "; Color: " + color.strName +
                                                     "; Qty: " + detail.Quantity.ToString());
                }

          
                sale.Description = productDetailsBuilder.ToString();
                unitOfWork.Sale.Add(sale);
                UpdateSaleCount(unitOfWork, sale, saleDetailsList);
                AddSalesCustomerLedger(unitOfWork, sale);
                AddGLTranForSale(unitOfWork, sale, tblGLTranDetail, useDefaultEntry);
                AddGLTranInventoryForSale(unitOfWork, sale);
                unitOfWork.Complete();
                return sale;
            }
        }

        private void AddSaleDetails(Sale sale, List<SalesDetail> saleDetailsList, UnitOfWork unitOfWork)
        {
            
            foreach (var item in saleDetailsList)
            {
         
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(item.ProductId ?? 0);
                sale.SalesDetails.Add(new SalesDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                    Product = product
                });

                sale.Stocks.Add(new Stock
                {
                    ProductId = item.ProductId,
                    QuantityIn = 0,
                    QuantityOut = item.Quantity,
                    StockTransactionTypeID = 2, // Assuming 2 is the ID for sale transaction
                    SalesID = sale.Id,
                    Product = product
                });
            }
        }

        private void UpdateSaleCount(UnitOfWork unitOfWork, Sale sale, List<SalesDetail> saleDetailsList)
        {
            foreach (var detail in saleDetailsList)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;

                if (productID == 0)
                    continue; // Skip the iteration if ProductId is not set

                var product = unitOfWork.Products.Get(productID);

                if (product == null)
                    continue; // Skip the iteration if no product is found for the given ID

                var newStocksOut = sale.Stocks.ToList();
                var intRemainingCount = GetTotalRemainingStock(unitOfWork, productID, newStocksOut);

                if (intRemainingCount < 0)
                {

                    throw new Exception($"Product " + product.strProductName + " " + product.ProductBrand.strName + " has no remaing count");
                    return;
                }
                product.intRemainingCount = intRemainingCount;

            }
        }


        public int GetTotalRemainingStock(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId)); // Include new stocks
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        }

        private void AddSalesCustomerLedger(UnitOfWork unitOfWork, Sale sale)
        {
            var saleCustomerLedger = new SalesCustomerLedger
            {
                intIdSales = sale.Id,
                intIdCustomer = sale.intIdCustomer,
                intIdSalesCustomerLedgerTransctionType = 1,
                TotalAmount = sale.Total,
                TransactionDate = sale.TransactionDate,
                TransactionNo = sale.TRANo,
                DateInserted = DateTime.Now
            };

            unitOfWork.SalesCustomerLedger.Add(saleCustomerLedger);
        }

        private void AddGLTranForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool useDefaultEntry)
        {
            if (useDefaultEntry)
            {
                AddDefaultGLTranForSale(unitOfWork, sale);
            }
            else
            {
                AddCustomGLTranForSale(unitOfWork, sale, tblGLTranDetail);
            }
        }


        private void AddDefaultGLTranForSale(UnitOfWork unitOfWork, Sale sale)
        {
            // Assuming IDs for SALES related account codes
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
            var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
            var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, sale.Total.Value),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, sale.SOPAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, sale.COMMAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry4.intIDMasCOA, journalEntry4.ID, sale.CFAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry5.intIDMasCOA, journalEntry5.ID, sale.Total.Value - (sale.COMMAmount.Value + sale.SOPAmount.Value + sale.CFAmount.Value), 0),
            };

            AddGLTranHeaderForSale(unitOfWork, sale, gLTranDetail);
        }

        private void AddCustomGLTranForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> tblGLTranDetail)
        {

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(sale.Description);
            productDetailsBuilder.AppendLine("( " + sale.AdditionalDescription + " )");

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 6, // Update this ID based on your system configuration for sales
                strDescription = productDetailsBuilder.ToString(),
                strTransactionCode = sale.TRANo,
                //strDescription = sale.Description,
                datBatchDate = sale.TransactionDate,
                datInsertedDate = DateTime.Now,
                intIdSales = sale.Id,
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


        private void AddGLTranHeaderForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> gLTranDetail)
        {
            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(sale.Description);
            productDetailsBuilder.AppendLine("( " + sale.AdditionalDescription + " )");

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 6, // Update if necessary
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = sale.TransactionDate,
                strTransactionCode = sale.TRANo,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdSales = sale.Id,
                blnUseDefaultEntry = true
            };

            unitOfWork.GLTran.Add(gLTranHeader);
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

        private void AddGLTranInventoryForSale(UnitOfWork unitOfWork, Sale sale)
        {
            // Logic for adding inventory transactions based on the sale.

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1072).SingleOrDefault(); // COST OF GOODS SOLD
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY

            var inventorySaleTotal = sale.SalesDetails.Sum(i => i.TotalPrice).Value;

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, 0, inventorySaleTotal),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, inventorySaleTotal, 0),
            };

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(sale.Description);
            productDetailsBuilder.AppendLine("( " + sale.AdditionalDescription + " )");

            //AddGLTranHeader(unitOfWork, purchase, gLTranDetail);

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strDescription = productDetailsBuilder.ToString(),
                strTransactionCode = sale.PONo,
                datBatchDate = sale.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdSales = sale.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }


        public List<Sale> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetAll().ToList();
            }
        }

        public Sale GetSale(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.Get(Id);
            }
        }

        public List<Sale> GetSalesWithoutReturnSales(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSalesWithoutReturnSales(criteria).ToList();

            }
        }

        public List<Sale> GetSaleWithCustomerAgent(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithCustomerAgent(criteria).ToList();

            }
        }

        public Sale GetSaleWithCustomerAgent(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithCustomerAgent(Id);

            }
        }

        public List<Sale> GetSaleWithJournalEntry(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithJournalEntry(Id).ToList();

            }
        }

        //public void Remove(Sale sale, List<SalesDetail> salesDetails)
        //{
        //    using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
        //    {
        //        var resultSale = unitOfWork.Sale.GetSaleWithJournalEntry(sale.Id).SingleOrDefault();
        //        var tblGlTranDetails = resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
        //        unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
        //        var tblGLTranHeaders = resultSale.tblGLTranHeaders.ToList();
        //        unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
        //        var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdSales == sale.Id && s.intIdSalesCustomerLedgerTransctionType == 1).SingleOrDefault();
        //        unitOfWork.SalesCustomerLedger.Remove(salesLedger);
        //        unitOfWork.Sale.Remove(resultSale);
        //        unitOfWork.Complete();
        //    }
        //}

        public void Remove(Sale sale, List<SalesDetail> salesDetails)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultSale = unitOfWork.Sale.GetSaleWithJournalEntry(sale.Id).SingleOrDefault();
                if (resultSale == null)
                {
                    throw new Exception("Sale not found!");
                }

                RemoveSaleDetails(unitOfWork, salesDetails);
                RemoveGLTranForSale(unitOfWork, resultSale);
                RemoveSaleCustomerLedger(unitOfWork, sale);
                unitOfWork.Sale.Remove(resultSale);

                unitOfWork.Complete();
            }
        }


        private void RemoveSaleDetails(UnitOfWork unitOfWork, List<SalesDetail> SaleDetailsList)
        {
            foreach (var detail in SaleDetailsList)
            {
                RemoveSaleDetail(unitOfWork, detail);
                UpdateRemainingStockForSale(unitOfWork, detail);
            }
            SaleDetailsList.Clear();
        }

        private void RemoveSaleDetail(UnitOfWork unitOfWork, SalesDetail detail)
        {
            var saleDetailExist = unitOfWork.SaleDetail.Get(detail.Id);
            if (saleDetailExist != null)
            {
                unitOfWork.SaleDetail.Remove(saleDetailExist);
            }

            var existingStock = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId && s.SalesID == detail.SalesId).FirstOrDefault();
            if (existingStock != null)
            {
                unitOfWork.Stock.Remove(existingStock);
            }
        }

        private void UpdateRemainingStockForSale(UnitOfWork unitOfWork, SalesDetail detail)
        {
            int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
            var product = unitOfWork.Products.Get(productID);
            var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId).ToList();
            existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
            product.intRemainingCount = totalStocks;
        }


        private void RemoveGLTranForSale(UnitOfWork unitOfWork, Sale sale)
        {
            var tblGLTranHeaders = sale.tblGLTranHeaders.ToList();
            foreach (var header in tblGLTranHeaders)
            {
                var tblGlTranDetails = header.tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
            }
            unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
        }

        private void RemoveSaleCustomerLedger(UnitOfWork unitOfWork, Sale sale)
        {
            var saleLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdSales == sale.Id).SingleOrDefault();
            if (saleLedger != null)
            {
                unitOfWork.SalesCustomerLedger.Remove(saleLedger);
            }
        }



        public Sale Update(Sale updatedSale, List<tblGLTranDetail> updatedTblGLTranDetail, bool UseDefaultEntry, List<SalesDetail> updatedSalesDetailsList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                // 1. Update sale details and associated stock records
                UpdateSaleDetails(updatedSale, updatedSalesDetailsList, unitOfWork);

                // 2. Update sale record in the repository
                var saleInDb = unitOfWork.Sale.Get(updatedSale.Id);
                saleInDb.PONo = updatedSale.PONo; // Assuming Sale has a SaleNo similar to PONo
                saleInDb.TRANo = updatedSale.TRANo; // Assuming there's an invoice number for Sale
                saleInDb.intIdCustomer = updatedSale.intIdCustomer; // Assuming there's a customer linked to a sale
                saleInDb.intIdAgent = updatedSale.intIdAgent;
                saleInDb.SOPAmount = updatedSale.SOPAmount;
                saleInDb.COMMAmount = updatedSale.COMMAmount;
                saleInDb.CFAmount = updatedSale.CFAmount;
                saleInDb.Total = updatedSale.Total;
                saleInDb.AdditionalDescription = updatedSale.AdditionalDescription;
                saleInDb.TransactionDate = updatedSale.TransactionDate;

                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in updatedSalesDetailsList)
                {
                    var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                    var size = product.ProductSize; // Assuming Product has a Size property
                    var color = product.ProductColor; // Assuming Product has a Color property

                    productDetailsBuilder.AppendLine("# " + product.strProductName +
                                                     "; Size: " + size.strName +
                                                     "; Color: " + color.strName +
                                                     "; Qty: " + detail.Quantity.ToString());
                }
                saleInDb.Description = string.Concat(productDetailsBuilder.ToString());

                saleInDb.SalesDetails = updatedSale.SalesDetails;
                saleInDb.Stocks = updatedSale.Stocks;
                updatedSale.Description = saleInDb.Description;

                // 3. Update remaining stock count for products in sale details
                UpdateRemainingCountForSale(unitOfWork, updatedSale, updatedSalesDetailsList); // Assuming there's an equivalent function for sale

                // 4. Update sale customer ledger record
                UpdateSalesCustomerLedger(unitOfWork, updatedSale);

                // 5. Update general ledger transaction records for sale
                UpdateGLTranForSale(unitOfWork, updatedSale, updatedTblGLTranDetail, UseDefaultEntry);

                // 6. Update inventory general ledger transactions related to the sale
                UpdateGLTranInventoryForSale(unitOfWork, updatedSale);

                // 7. Commit changes to the database
                unitOfWork.Complete();

         

                return updatedSale;
            }
        }

        private void UpdateSaleDetails(Sale updatedSale, List<SalesDetail> updatedSalesDetailsList, UnitOfWork unitOfWork)
        {
            // Delete existing sales details and stock records
            foreach (var existingDetail in updatedSale.SalesDetails.ToList())
            {
                var salesDetailExist = unitOfWork.SaleDetail.Get(existingDetail.Id);
                unitOfWork.SaleDetail.Remove(salesDetailExist);

                // We assume that the stock decreases when a sale is made. 
                var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.SalesID == existingDetail.SalesId).FirstOrDefault();
                if (existingStock != null)
                {
                    unitOfWork.Stock.Remove(existingStock);
                }

                int productID = (existingDetail.ProductId.HasValue) ? existingDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.Get(productID);
                var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId).ToList();
                existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
                var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
                product.intRemainingCount = totalStocks;
            }
            updatedSale.SalesDetails.Clear();
            updatedSale.Stocks.Clear();

            // Add new sales details and stock records
            foreach (var updatedDetail in updatedSalesDetailsList)
            {

                int productID = (updatedDetail.ProductId.HasValue) ? updatedDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(productID);

                updatedSale.SalesDetails.Add(new SalesDetail
                {
                    //SaleId = updatedDetail.Id, 
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice,
                    Product = product

                });

                updatedSale.Stocks.Add(new Stock
                {
                    ProductId = updatedDetail.ProductId,
                    QuantityIn = 0,  // For sales, there's no incoming stock
                    QuantityOut = updatedDetail.Quantity,
                    StockTransactionTypeID = 2,  // Assuming '2' indicates a sales transaction. Adjust if needed.
                    SalesID = updatedSale.Id
                });
            }
        }

        public void UpdateRemainingCountForSale(UnitOfWork unitOfWork, Sale sale, List<SalesDetail> SalesDetailsList)
        {
            foreach (var detail in SalesDetailsList)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;

                var product = unitOfWork.Products.Get(productID);

                // Part 1: Your implementation start here...
                // You might want to get the stock list specific to the product
                //var stocks = unitOfWork.Stock.FindLocal(s => s.ProductId == detail.ProductId).ToList();

                var newStocks = sale.Stocks.ToList();
                //TODO: here minus the last updated Product
                var intRemainingCount =  GetTotalRemainingStockAfterSale(unitOfWork, productID, newStocks);

                if (intRemainingCount < 0)
                {

                    throw new Exception($"Product " + product.strProductName + " " + product.ProductBrand.strName + " has no remaing count");
                    return;
                }

                product.intRemainingCount = intRemainingCount;
            }
        }

        public int GetTotalRemainingStockAfterSale(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId)); // Include new stocks

            // Adjusting for sales, which reduce the stock count
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        }

        private void UpdateSalesCustomerLedger(UnitOfWork unitOfWork, Sale updatedSale)
        {
            // Find and delete existing sales customer ledger record
            var existingSalesCustomerLedger = unitOfWork.SalesCustomerLedger.Find(scl => scl.intIdSales == updatedSale.Id).SingleOrDefault();
            if (existingSalesCustomerLedger != null)
            {
                unitOfWork.SalesCustomerLedger.Remove(existingSalesCustomerLedger);
            }

            // Add new sales customer ledger record
            var salesCustomerLedger = new SalesCustomerLedger
            {
                intIdSales = updatedSale.Id,
                intIdCustomer = updatedSale.intIdCustomer, // I'm assuming the Sale model has a similar property to the Purchase's intIDSupplier
                intIdSalesCustomerLedgerTransctionType = 1, // Assuming a transaction type exists similar to the Purchase's
                TotalAmount = updatedSale.Total,
                TransactionDate = updatedSale.TransactionDate,
                TransactionNo = updatedSale.TRANo, // Assuming the Sale model has a TRANo property similar to Purchase
                DateInserted = DateTime.Now
            };
            unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);
        }


        private void UpdateGLTranForSale(UnitOfWork unitOfWork, Sale updatedSale, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            // Delete existing GLTran entries for the sale
            var existingGLTranHeader = unitOfWork.GLTran.Find(h => h.intIdSales == updatedSale.Id && h.intIDGLBookType == 6).SingleOrDefault();
            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);

                if (existingGLTranDetail != null)
                {
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
                }
            }

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(updatedSale.Description);
            productDetailsBuilder.AppendLine("( " + updatedSale.AdditionalDescription + " )");

            existingGLTranHeader.datBatchDate = updatedSale.TransactionDate;
            existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
            existingGLTranHeader.blnUseDefaultEntry = UseDefaultEntry;
            existingGLTranHeader.strTransactionCode = updatedSale.TRANo;

            // Re-insert the GLTran entries for the sale
            if (UseDefaultEntry)
            {
                // Using example journal entries; you'll need to adjust based on your Sale's ledger details
                var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // ACCOUNTS PAYABLE- COMMISSIONS
                var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // ACCOUNTS PAYABLE- SOP
                var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // ACCOUNTS PAYABLE- COMMON FUND
                var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES


                var gLTranDetail = new List<tblGLTranDetail>
                {
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                        intIDMasCoaSub = journalEntry1.ID,
                        curCredit = 0,
                        curDebit = updatedSale.Total.Value,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    },
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry2.intIDMasCOA,
                        intIDMasCoaSub = journalEntry2.ID,
                        curCredit = updatedSale.SOPAmount,
                        curDebit = 0,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    },
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                        intIDMasCoaSub = journalEntry3.ID,
                        curCredit = updatedSale.COMMAmount,
                        curDebit = 0,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    },
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry4.intIDMasCOA,
                        intIDMasCoaSub = journalEntry4.ID,
                        curCredit = updatedSale.CFAmount,
                        curDebit = 0,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    },
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry5.intIDMasCOA,
                        intIDMasCoaSub = journalEntry5.ID,
                        curCredit = updatedSale.Total.Value - (updatedSale.SOPAmount + updatedSale.COMMAmount + updatedSale.CFAmount),
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

        private void UpdateGLTranInventoryForSale(UnitOfWork unitOfWork, Sale updatedSale)
        {
            // Delete existing GLTran entries for the sale
            var existingGLTranHeader = unitOfWork.GLTran.Find(h => h.intIdSales == updatedSale.Id && h.intIDGLBookType == 1011).SingleOrDefault();
            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);

                if (existingGLTranDetail != null)
                {
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
                }
                // If you wish to delete the GLTran header, you can uncomment the line below.
                //unitOfWork.GLTran.Remove(existingGLTranHeader);
            }


            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(updatedSale.Description);
            productDetailsBuilder.AppendLine("( " + updatedSale.AdditionalDescription + " )");

            existingGLTranHeader.datBatchDate = updatedSale.TransactionDate;
            existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
            existingGLTranHeader.strTransactionCode = updatedSale.PONo;
            existingGLTranHeader.blnUseDefaultEntry = true;

            // Re-insert the GLTran entries for the sale
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1072).SingleOrDefault(); // Example: COST OF GOODS SOLD
            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY


            var inventorySaleTotal = updatedSale.SalesDetails.Sum(i => i.TotalPrice).Value;


            var gLTranDetail = new List<tblGLTranDetail>
            {
                 new tblGLTranDetail
                {
                    intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                    intIDMasCoaSub = journalEntry1.ID,
                    curCredit = 0,
                    curDebit = inventorySaleTotal,
                    intIDGLTranHeader = existingGLTranHeader.ID
                },
                new tblGLTranDetail
                {
                    intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                    intIDMasCoaSub = journalEntry3.ID,
                    curCredit =  inventorySaleTotal,
                    curDebit = 0,
                    intIDGLTranHeader = existingGLTranHeader.ID
                }
              
            };

            unitOfWork.GLTranDetail.AddRange(gLTranDetail);
            existingGLTranHeader.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
            existingGLTranHeader.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);
        }


    }
}
