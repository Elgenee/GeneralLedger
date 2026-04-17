using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;
using GeneralLedger.Persistence.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Persistence.Services
{
    public class PurchaseServices : IPurchaseServices
    {
        public Purchase Add(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> PurchaseDetailsList)
        {
            try
            {

          
            // ✅ Changed from: SimpleLogger.Info($"Add Purchase: Starting...")
            SimpleLogger.LogPurchaseOperation("ADD_START", 0, purchase.intIDSupplier, purchase.Total);
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
                {
                    AddPurchaseDetails(purchase, PurchaseDetailsList, unitOfWork);

                    var supplier = unitOfWork.Supplier.Get(purchase.intIDSupplier.Value);

                    StringBuilder productDetailsBuilder = new StringBuilder();
                    foreach (var detail in PurchaseDetailsList)
                    {
                        var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                        var size = product.ProductSize; // Assuming Product has a Size property
                        var color = product.ProductColor; // Assuming Product has a Color property
                        var prodType = product?.ProductType;

                    // Calculate total price for this product line
                    decimal unitPrice = product?.curUnitPrice ?? 0;
                    int qty = detail.Quantity ?? 0;
                    decimal totalPrice = unitPrice * qty;

                    productDetailsBuilder.AppendLine("# " +
                               (product?.strProductName ?? string.Empty) +
                               "; Size: " + (size?.strName ?? string.Empty) +
                               "; Color: " + (color?.strName ?? string.Empty) +
                               "; ProdType: " + (prodType?.strName ?? string.Empty) +
                               (!string.IsNullOrEmpty(product?.strPR) ? "; PR: " + product.strPR : "") +
                               "; Price: " + unitPrice.ToString("N2") +
                               "; Qty: " + qty.ToString() +
                               "; Total: " + totalPrice.ToString("N2"));
                    }

                    productDetailsBuilder.AppendLine("Supplier: " + supplier?.strName ?? string.Empty);

                    purchase.Description = productDetailsBuilder.ToString();
                    unitOfWork.Purchase.Add(purchase);
                    UpdateRemainingCount(unitOfWork,purchase, PurchaseDetailsList);
                    AddPurchaseSupplierLedger(unitOfWork, purchase);
                    AddGLTran(unitOfWork, purchase, tblGLTranDetail, UseDefaultEntry);
                    AddGLTranInventory(unitOfWork, purchase);
                    unitOfWork.Complete();
                    // ✅ Changed from: SimpleLogger.Info($"Add Purchase: Success...")
                    SimpleLogger.LogPurchaseOperation("ADD_SUCCESS", purchase.Id, purchase.intIDSupplier, purchase.Total);
                    return purchase;
                }

            }
            catch (Exception ex)
            {
                SimpleLogger.LogCriticalError("ADD_PURCHASE", $"SupplierId: {purchase.intIDSupplier}, Total: {purchase.Total}", ex);
                throw;
            }
        }

        public int GetTotalRemainingStock(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId)); // Include new stocks
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        }


        public void UpdateRemainingCount(UnitOfWork unitOfWork, Purchase purchase, List<PurchaseDetail> PurchaseDetailsList)
        {
            
                foreach (var detail in PurchaseDetailsList)
                {
                    int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
         
                    var product = unitOfWork.Products.Get(productID);

                // Part 1: Your implementation start here...
                // You might want to get the stock list specific to the product
                //var stocks = unitOfWork.Stock.FindLocal(s => s.ProductId == detail.ProductId).ToList();

                    var newStocks = purchase.Stocks.ToList();
                    product.intRemainingCount = GetTotalRemainingStock(unitOfWork , productID, newStocks);
                   
                   
                }
        }

        private void AddPurchaseDetails(Purchase purchase, List<PurchaseDetail> PurchaseDetailsList, UnitOfWork unitOfWork)
        {
            // ✅ Changed from: SimpleLogger.Info($"AddPurchaseDetails: Processing...")
            SimpleLogger.LogPurchaseOperation("ADD_DETAILS_START", purchase.Id, null, null);
            foreach (var item in PurchaseDetailsList)
            {
                // ✅ Use purchase detail logging
                SimpleLogger.LogPurchaseDetailOperation("ADD", null, purchase.Id, item.ProductId, item.Quantity, item.UnitPrice, item.TotalPrice);

                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(item.ProductId ?? 0);
                purchase.PurchaseDetails.Add(new PurchaseDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                    Product = product
              
                });

                // ✅ UPDATE THIS LINE (around line 107)
                SimpleLogger.LogStockCreation(
                    item.ProductId.Value,
                    null,         // salesId
                    purchase.Id,  // purchaseId
                    null,         // inventoryAdjustmentId
                    1,            // stockTransactionTypeId (1 = Purchase)
                    item.Quantity.Value,  // quantityIn
                    0             // quantityOut
                );


                purchase.Stocks.Add(new Stock
                {

                    ProductId = item.ProductId,
                    QuantityIn = item.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 1,
                    PurchaseID = purchase.Id,
                    Product = product,
                    TransactionDate = purchase.TransactionDate
                });

            }
        }

        private void AddPurchaseSupplierLedger(UnitOfWork unitOfWork, Purchase purchase)
        {
            var purchaseCustomerLedger = new PurchaseSupplierLedger
            {
                intIdPurchase = purchase.Id,
                intIdSupplier = purchase.intIDSupplier,
                intIdPurchaseSupplierLedgerTransactionType = 1,
                TotalAmount = purchase.Total,
                TransactionDate = purchase.TransactionDate,
                TransactionNo = purchase.TRANo,
                DateInserted = DateTime.Now
            };
            unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);
        }

        public void AddGLTranInventory(UnitOfWork unitOfWork, Purchase purchase) {

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var inventoryTotal = purchase.PurchaseDetails.Sum(g => g.TotalPrice);

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, 0, inventoryTotal),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, inventoryTotal, 0),
            };

            //AddGLTranHeader(unitOfWork, purchase, gLTranDetail);

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(purchase.Description);
            productDetailsBuilder.AppendLine("( " + purchase.AdditionalDescription + " )");

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strTransactionCode = purchase.PONo,
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = purchase.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdPurchase = purchase.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        private void AddGLTran(UnitOfWork unitOfWork, Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            if (UseDefaultEntry)
            {
                AddDefaultGLTran(unitOfWork, purchase);
            }
            else
            {
                AddCustomGLTran(unitOfWork, purchase, tblGLTranDetail);
            }
        }

        private void AddDefaultGLTran(UnitOfWork unitOfWork, Purchase purchase)
        {
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

        
            var gLTranDetail = new List<tblGLTranDetail>
            {

                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, purchase.Total.Value),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, purchase.Total.Value, 0),
              
            };

              AddGLTranHeader(unitOfWork, purchase, gLTranDetail);
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

        private void AddGLTranHeader(UnitOfWork unitOfWork, Purchase purchase, List<tblGLTranDetail> gLTranDetail)
        {

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(purchase.Description);
            productDetailsBuilder.AppendLine("( " + purchase.AdditionalDescription + " )");
            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 9,
                strDescription =  productDetailsBuilder.ToString(),
                datBatchDate = purchase.TransactionDate,
                strTransactionCode = purchase.TRANo,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdPurchase = purchase.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        private void AddCustomGLTran(UnitOfWork unitOfWork, Purchase purchase, List<tblGLTranDetail> tblGLTranDetail)
        {

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(purchase.Description);
            productDetailsBuilder.AppendLine("( " + purchase.AdditionalDescription + " )");


            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 9,
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = purchase.TransactionDate,
                strTransactionCode = purchase.TRANo,
                datInsertedDate = DateTime.Now,
                intIdPurchase = purchase.Id,
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


  


        public List<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchase(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchasesWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseWithoutReturnPurchase(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Purchase.GetPurchaseWithoutReturnPurchases(criteria).ToList();

            }
        }

        public List<Purchase> GetPurchaseWithSupplier(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Purchase.GetPurchaseWithSupplier(criteria).ToList();

            }
        }

        public Purchase GetPurchaseWithSupplier(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Purchase.GetPurchaseWithSupplier(Id);

            }
        }

        //public void Remove(Purchase purchase, List<PurchaseDetail> PurchaseDetailsList)
        //{
        //    using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
        //    {
        //        var resultPurchase = unitOfWork.Purchase.GetPurchasesWithJournalEntry(purchase.Id).SingleOrDefault();

        //        foreach (var detail in PurchaseDetailsList) {

        //            var purchaseDetailExist = unitOfWork.PurchaseDetail.Get(detail.Id);
        //            unitOfWork.PurchaseDetail.Remove(purchaseDetailExist);

        //            var existingStock = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId && s.PurchaseID == detail.PurchaseId).FirstOrDefault();

        //            if (existingStock != null)
        //            {
        //                unitOfWork.Stock.Remove(existingStock);
        //            }

        //            int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
        //            var product = unitOfWork.Products.Get(productID);
        //            var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId).ToList();
        //            existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
        //            var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        //            product.intRemainingCount = totalStocks;
        //        }

        //        PurchaseDetailsList.Clear();

        //        var tblGlTranDetails = resultPurchase.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
        //        unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
        //        var tblGLTranHeaders = resultPurchase.tblGLTranHeaders.ToList();
        //        unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
        //        var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPurchase == purchase.Id && p.intIdPurchaseSupplierLedgerTransactionType == 1).SingleOrDefault();
        //        unitOfWork.PurchaseSupplierLedger.Remove(purchaseLedger);
        //        unitOfWork.Purchase.Remove(resultPurchase);
        //        unitOfWork.Complete();
        //    }
        //}

        public void Remove(Purchase purchase, List<PurchaseDetail> PurchaseDetailsList)
        {
            try
            {
                // ✅ Changed from: SimpleLogger.Info($"Remove Purchase: Starting...")
                SimpleLogger.LogPurchaseOperation("REMOVE_START", purchase.Id, purchase.intIDSupplier, purchase.Total);
                using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
                {
                    var resultPurchase = unitOfWork.Purchase.GetPurchasesWithJournalEntry(purchase.Id).SingleOrDefault();
                    if (resultPurchase == null)
                    {
                        SimpleLogger.Error($"Remove Purchase: Purchase not found - PurchaseId: {purchase.Id}");
                        throw new Exception("Purchase not found!");
                    }

                    RemovePurchaseDetails(unitOfWork, PurchaseDetailsList);
                    RemoveGLTran(unitOfWork, resultPurchase);
                    RemovePurchaseSupplierLedger(unitOfWork, purchase);
                    unitOfWork.Purchase.Remove(resultPurchase);

                    unitOfWork.Complete();

                    // ✅ Changed from: SimpleLogger.Info($"Remove Purchase: Success...")
                    SimpleLogger.LogPurchaseOperation("REMOVE_SUCCESS", purchase.Id, purchase.intIDSupplier, purchase.Total);
                }
            }
            catch (Exception ex)
            {

                SimpleLogger.LogCriticalError("REMOVE_PURCHASE", $"PurchaseId: {purchase.Id}", ex);
                throw;
            }
        }

        private void RemovePurchaseDetails(UnitOfWork unitOfWork, List<PurchaseDetail> PurchaseDetailsList)
        {
            // ✅ Changed from: SimpleLogger.Info($"RemovePurchaseDetails: Removing...")
            SimpleLogger.LogPurchaseOperation("REMOVE_DETAILS_START", 0, null, null);
            foreach (var detail in PurchaseDetailsList)
            {
                RemovePurchaseDetail(unitOfWork, detail);
                UpdateRemainingStock(unitOfWork, detail);
            }
            PurchaseDetailsList.Clear();
        }

        private void RemovePurchaseDetail(UnitOfWork unitOfWork, PurchaseDetail detail)
        {
            // ✅ Use purchase detail logging
            SimpleLogger.LogPurchaseDetailOperation("REMOVE", detail.Id, detail.PurchaseId, detail.ProductId, detail.Quantity, detail.UnitPrice, detail.TotalPrice);

            var purchaseDetailExist = unitOfWork.PurchaseDetail.Get(detail.Id);
            if (purchaseDetailExist != null)
            {
                unitOfWork.PurchaseDetail.Remove(purchaseDetailExist);
            }

            int productID = detail.ProductId.HasValue ? detail.ProductId.Value : 0;
            int purchaseId = detail.PurchaseId.HasValue ? detail.PurchaseId.Value : 0;

            // ✅ UPDATE THIS LINE (around line 269)
            SimpleLogger.LogStockQuery(
                productID,
                null,         // salesId
                purchaseId,   // purchaseId
                null,         // inventoryAdjustmentId
                1             // stockTransactionTypeId
            );

            var existingStock = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId && s.PurchaseID == detail.PurchaseId).FirstOrDefault();
            if (existingStock != null)
            {
                // ✅ UPDATE THIS LINE (around line 281)
                SimpleLogger.LogStockDeletion(
                    existingStock.Id,
                    existingStock.ProductId.Value,
                    null,                            // salesId
                    existingStock.PurchaseID,        // purchaseId
                    null,                            // inventoryAdjustmentId
                    existingStock.StockTransactionTypeID.Value,
                    existingStock.QuantityIn.Value,
                    existingStock.QuantityOut.Value,
                    $"Purchase Detail Removal - DetailId: {detail.Id}"
                );

                unitOfWork.Stock.Remove(existingStock);
            }
            else
            {
                // ✅ UPDATE THIS LINE (around line 295)
                SimpleLogger.LogStockNotFound(productID, null, purchaseId, null);
            }

        }

        private void UpdateRemainingStock(UnitOfWork unitOfWork, PurchaseDetail detail)
        {
            int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;
            var product = unitOfWork.Products.Get(productID);
            var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == detail.ProductId).ToList();
            existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
            product.intRemainingCount = totalStocks;
        }

        private void RemoveGLTran(UnitOfWork unitOfWork, Purchase purchase)
        {
            var tblGLTranHeaders = purchase.tblGLTranHeaders.ToList();
            foreach (var header in tblGLTranHeaders)
            {
                var tblGlTranDetails = header.tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
            }
            unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
        }

        private void RemovePurchaseSupplierLedger(UnitOfWork unitOfWork, Purchase purchase)
        {
            var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPurchase == purchase.Id && p.intIdPurchaseSupplierLedgerTransactionType == 1).SingleOrDefault();
            if (purchaseLedger != null)
            {
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseLedger);
            }
        }


        //private void DeletePurchaseDetails(UnitOfWork unitOfWork, Purchase purchase)
        //{
        //    var purchaseDetails = purchase.PurchaseDetails.ToList();
        //    foreach (var detail in purchaseDetails)
        //    {
        //        // Decrease the stock when deleting the purchase detail
        //        var stock = unitOfWork.Stock.SingleOrDefault(s => s.PurchaseID == purchase.Id && s.ProductId == detail.ProductId);
        //        if (stock != null)
        //        {
        //            stock.QuantityIn -= detail.Quantity;
        //            unitOfWork.Stock.Update(stock);
        //        }

        //        // Remove the purchase detail
        //        unitOfWork.PurchaseDetails.Remove(detail);
        //    }
        //}

        //private void DeletePurchaseSupplierLedger(UnitOfWork unitOfWork, Purchase purchase)
        //{
        //    var purchaseSupplierLedger = unitOfWork.PurchaseSupplierLedger.SingleOrDefault(psl => psl.intIdPurchase == purchase.Id);
        //    if (purchaseSupplierLedger != null)
        //    {
        //        unitOfWork.PurchaseSupplierLedger.Remove(purchaseSupplierLedger);
        //    }
        //}

        //private void DeleteGLTran(UnitOfWork unitOfWork, Purchase purchase)
        //{
        //    var glTrans = unitOfWork.GLTran.Find(glt => glt.intIdPurchase == purchase.Id).ToList();
        //    foreach (var tran in glTrans)
        //    {
        //        unitOfWork.GLTran.Remove(tran);
        //    }
        //}

        public Purchase Update(Purchase updatedPurchase, List<tblGLTranDetail> updatedTblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> updatedPurchaseDetailsList)
        {
            try
            {
                // ✅ Changed from: SimpleLogger.Info($"Update Purchase: Starting...")
                SimpleLogger.LogPurchaseOperation("UPDATE_START", updatedPurchase.Id, updatedPurchase.intIDSupplier, updatedPurchase.Total);
                using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
                {
                    // 1. Update purchase details and associated stock records
                    UpdatePurchaseDetails(updatedPurchase, updatedPurchaseDetailsList, unitOfWork);

                    var supplier = unitOfWork.Supplier.Get(updatedPurchase.intIDSupplier.Value);


                    // 2. Update purchase record in the repository
                    var pur = unitOfWork.Purchase.Get(updatedPurchase.Id);

                    // ✅ Log individual property updates
                    if (pur.PONo != updatedPurchase.PONo)
                        SimpleLogger.LogPurchaseUpdate(updatedPurchase.Id, "PONo", pur.PONo, updatedPurchase.PONo);

                    if (pur.Total != updatedPurchase.Total)
                        SimpleLogger.LogPurchaseUpdate(updatedPurchase.Id, "Total", pur.Total?.ToString("F2"), updatedPurchase.Total?.ToString("F2"));

                    pur.PONo = updatedPurchase.PONo;
                    pur.SIDR = updatedPurchase.SIDR;
                    pur.TRANo = updatedPurchase.TRANo;
                    pur.intIDSupplier = updatedPurchase.intIDSupplier;
                    pur.Total = updatedPurchase.Total;
                    pur.TransactionDate = updatedPurchase.TransactionDate;

                    StringBuilder productDetailsBuilder = new StringBuilder();
                    foreach (var detail in updatedPurchaseDetailsList)
                    {
                        var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                        var size = product.ProductSize; // Assuming Product has a Size property
                        var color = product.ProductColor; // Assuming Product has a Color property
                        var prodType = product?.ProductType;

                        // Calculate total price for this product line
                        decimal unitPrice = product?.curUnitPrice ?? 0;
                        int qty = detail.Quantity ?? 0;
                        decimal totalPrice = unitPrice * qty;

                        productDetailsBuilder.AppendLine("# " +
                              (product?.strProductName ?? string.Empty) +
                              "; Size: " + (size?.strName ?? string.Empty) +
                              "; Color: " + (color?.strName ?? string.Empty) +
                              "; ProdType: " + (prodType?.strName ?? string.Empty) +
                              (!string.IsNullOrEmpty(product?.strPR) ? "; PR: " + product.strPR : "") +
                               "; Price: " + unitPrice.ToString("N2") +
                               "; Qty: " + qty.ToString() +
                               "; Total: " + totalPrice.ToString("N2"));
                    }
                    productDetailsBuilder.AppendLine("Supplier: " + supplier?.strName ?? string.Empty);

                    pur.Description = string.Concat(productDetailsBuilder.ToString());

                    pur.PurchaseDetails = updatedPurchase.PurchaseDetails;
                    pur.Stocks = updatedPurchase.Stocks;
                    updatedPurchase.Description = pur.Description;
                    // 3. Update remaining stock count for products in purchase details
                    UpdateRemainingCount(unitOfWork, updatedPurchase, updatedPurchaseDetailsList);

                    // 4. Update purchase supplier ledger record
                    UpdatePurchaseSupplierLedger(unitOfWork, updatedPurchase);

                    //// 5. Update general ledger transaction records
                    UpdateGLTran(unitOfWork, updatedPurchase, updatedTblGLTranDetail, UseDefaultEntry);


                    UpdateGLTranInventory(unitOfWork, updatedPurchase);

                    // 6. Commit changes to the database
                    unitOfWork.Complete();


                    // ✅ Changed from: SimpleLogger.Info($"Update Purchase: Success...")
                    SimpleLogger.LogPurchaseOperation("UPDATE_SUCCESS", updatedPurchase.Id, updatedPurchase.intIDSupplier, updatedPurchase.Total);

                    return updatedPurchase;
                }
            }
            catch (Exception ex)
            {
                SimpleLogger.LogCriticalError("UPDATE_PURCHASE", $"PurchaseId: {updatedPurchase.Id}", ex);
                throw ex;
            }
       
        }


        private void UpdatePurchaseDetails(Purchase updatedPurchase, List<PurchaseDetail> updatedPurchaseDetailsList, UnitOfWork unitOfWork)
        {
            int purchaseId = updatedPurchase.Id;

            if (purchaseId <= 0)
            {
                SimpleLogger.Error($"UpdatePurchaseDetails: Invalid Purchase ID: {purchaseId}");
                throw new InvalidOperationException("Cannot update purchase details: Invalid Purchase ID");
            }

            // ✅ Changed from: SimpleLogger.Info($"UpdatePurchaseDetails: Starting...")
            SimpleLogger.LogPurchaseOperation("UPDATE_DETAILS_START", purchaseId, null, null);

            var existingDetailsFromDb = unitOfWork.PurchaseDetail
                .Find(pd => pd.PurchaseId == purchaseId)
                .ToList();

            SimpleLogger.Info($"UpdatePurchaseDetails: Found {existingDetailsFromDb.Count} existing details for PurchaseId: {purchaseId}");
            // Delete existing purchase details and stock records
            foreach (var existingDetail in existingDetailsFromDb)
            {

                int productID = existingDetail.ProductId.HasValue ? existingDetail.ProductId.Value : 0;
                // ✅ Use purchase detail logging
                SimpleLogger.LogPurchaseDetailOperation("DELETE", existingDetail.Id, purchaseId, existingDetail.ProductId, existingDetail.Quantity, existingDetail.UnitPrice, existingDetail.TotalPrice);

                var purchaseDetailExist = unitOfWork.PurchaseDetail.Get(existingDetail.Id);
                if (purchaseDetailExist != null)
                {
                    unitOfWork.PurchaseDetail.Remove(purchaseDetailExist);
                }

                if (productID <= 0)
                {
                    SimpleLogger.Warning($"UpdatePurchaseDetails: Invalid ProductId in existing detail: {existingDetail.Id}");
                    continue;
                }

                // ✅ UPDATE THIS LINE (around line 352)
                SimpleLogger.LogStockQuery(
                    productID,
                    null,         // salesId
                    purchaseId,   // purchaseId
                    null,         // inventoryAdjustmentId
                    1             // stockTransactionTypeId
                );

                var existingStock = unitOfWork.Stock.Find(s =>
                    s.ProductId == productID &&
                    s.PurchaseID == purchaseId &&
                    s.StockTransactionTypeID == 1
                ).FirstOrDefault();
                //var existingStock = updatedPurchase.Stocks.FirstOrDefault(s => s.ProductId == existingDetail.ProductId);

                if (existingStock != null)
                {
                    // ✅ UPDATE THIS LINE (around line 365)
                    SimpleLogger.LogStockDeletion(
                        existingStock.Id,
                        existingStock.ProductId.Value,
                        null,                            // salesId
                        existingStock.PurchaseID,        // purchaseId
                        null,                            // inventoryAdjustmentId
                        existingStock.StockTransactionTypeID.Value,
                        existingStock.QuantityIn.Value,
                        existingStock.QuantityOut.Value,
                        $"Purchase Update - PurchaseId: {purchaseId}"
                    );

                    unitOfWork.Stock.Remove(existingStock);
                }
                else
                {
                    SimpleLogger.LogStockNotFound(productID, null, purchaseId, null);
                }

                var product = unitOfWork.Products.Get(productID);
                var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == productID).ToList();
                existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
                var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
                SimpleLogger.LogStockValidation(productID, product.strProductName, totalStocks, 0, true);
                product.intRemainingCount = totalStocks;

            }
            updatedPurchase.PurchaseDetails.Clear();
            updatedPurchase.Stocks.Clear();

            // Add new purchase details and stock records
            foreach (var updatedDetail in updatedPurchaseDetailsList)
            {

                int productID = (updatedDetail.ProductId.HasValue) ? updatedDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(productID);
                if (productID <= 0)
                {
                    SimpleLogger.Warning($"UpdatePurchaseDetails: Skipping detail with invalid ProductId");
                    continue;
                }


                // ✅ Use purchase detail logging
                SimpleLogger.LogPurchaseDetailOperation("ADD_NEW", null, purchaseId, productID, updatedDetail.Quantity, updatedDetail.UnitPrice, updatedDetail.TotalPrice);


                updatedPurchase.PurchaseDetails.Add(new PurchaseDetail
                {
                    //PurchaseId = updatedDetail.Id,
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice,
                    Product = product
                });

                // ✅ UPDATE THIS LINE (around line 423)
                SimpleLogger.LogStockCreation(
                    productID,
                    null,         // salesId
                    purchaseId,   // purchaseId
                    null,         // inventoryAdjustmentId
                    1,            // stockTransactionTypeId
                    updatedDetail.Quantity.Value,  // quantityIn
                    0             // quantityOut
                );

                updatedPurchase.Stocks.Add(new Stock
                {
                    ProductId = updatedDetail.ProductId,
                    QuantityIn = updatedDetail.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 1,
                    PurchaseID = updatedPurchase.Id,
                    TransactionDate = updatedPurchase.TransactionDate,
                });
            }

            // ✅ Changed from: SimpleLogger.Info($"UpdatePurchaseDetails: Complete...")
            SimpleLogger.LogPurchaseOperation("UPDATE_DETAILS_COMPLETE", purchaseId, null, null);
        }

        private void UpdatePurchaseSupplierLedger(UnitOfWork unitOfWork, Purchase updatedPurchase)
        {
            // Find and delete existing purchase supplier ledger record
            var existingPurchaseSupplierLedger = unitOfWork.PurchaseSupplierLedger.Find(psl => psl.intIdPurchase == updatedPurchase.Id && psl.intIdPurchaseSupplierLedgerTransactionType == 1).SingleOrDefault();
            if (existingPurchaseSupplierLedger != null)
            {
                unitOfWork.PurchaseSupplierLedger.Remove(existingPurchaseSupplierLedger);
            }

            // Add new purchase supplier ledger record
            var purchaseCustomerLedger = new PurchaseSupplierLedger
            {
                intIdPurchase = updatedPurchase.Id,
                intIdSupplier = updatedPurchase.intIDSupplier,
                intIdPurchaseSupplierLedgerTransactionType = 1,
                TotalAmount = updatedPurchase.Total,
                TransactionDate = updatedPurchase.TransactionDate,
                TransactionNo = updatedPurchase.TRANo,
                DateInserted = DateTime.Now
            };
            unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);
        }



        private void UpdateGLTranInventory(UnitOfWork unitOfWork, Purchase updatedPurchase)
        {
            // Delete existing GLTran entries for the purchase
            var existingGLTranHeader = unitOfWork.GLTran.Find(h => h.intIdPurchase == updatedPurchase.Id && h.intIDGLBookType == 1011).SingleOrDefault();

            StringBuilder productDetailsBuilder = new StringBuilder();
            productDetailsBuilder.AppendLine(updatedPurchase.Description);
            productDetailsBuilder.AppendLine("( " + updatedPurchase.AdditionalDescription + " )");

            // Re-insert the GLTran entries for the purchase

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var inventoryTotal = updatedPurchase.PurchaseDetails.Sum(g => g.TotalPrice);

            var gLTranDetail = new List<tblGLTranDetail>
             {
                    new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                        intIDMasCoaSub = journalEntry3.ID,
                        curCredit = 0,
                        curDebit = inventoryTotal,
                        //intIDGLTranHeader = existingGLTranHeader.ID
                    },
                  new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                        intIDMasCoaSub = journalEntry1.ID,
                        curCredit = inventoryTotal,
                        curDebit = 0,
                        //intIDGLTranHeader = existingGLTranHeader.ID
                    }

                    //CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, updatedPurchase.Total.Value),
                    //CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, updatedPurchase.Total.Value, 0)
             };


            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);

                if (existingGLTranDetail != null)
                {
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
                }
                //unitOfWork.GLTran.Remove(existingGLTranHeader);

                existingGLTranHeader.datBatchDate = updatedPurchase.TransactionDate;
                existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
                existingGLTranHeader.strTransactionCode = updatedPurchase.PONo;
                existingGLTranHeader.blnUseDefaultEntry = true;

                foreach (var detail in gLTranDetail)
                {
                    detail.intIDGLTranHeader = existingGLTranHeader.ID;
                }

                unitOfWork.GLTranDetail.AddRange(gLTranDetail);

                existingGLTranHeader.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
                existingGLTranHeader.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);
            }
            else {

                // Add new header and details
                var newGLTranHeader = new tblGLTranHeader
                {
                    curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                    curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                    intIDGLBookType = 1011,
                    strTransactionCode = updatedPurchase.PONo,
                    strDescription = productDetailsBuilder.ToString(),
                    datBatchDate = updatedPurchase.TransactionDate,
                    datInsertedDate = DateTime.Now,
                    tblGLTranDetails = gLTranDetail,
                    intIdPurchase = updatedPurchase.Id,
                    blnUseDefaultEntry = true
                };
                unitOfWork.GLTran.Add(newGLTranHeader);

            }
        }


        private void UpdateGLTran(UnitOfWork unitOfWork, Purchase updatedPurchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            // Delete existing GLTran entries for the purchase
            var existingGLTranHeader = unitOfWork.GLTran.Find(h => h.intIdPurchase == updatedPurchase.Id && h.intIDGLBookType == 9).SingleOrDefault();
            if (existingGLTranHeader != null)
            {
                var existingGLTranDetail = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeader.ID);

                if (existingGLTranDetail != null)
                {
                    unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetail);
                }
               //unitOfWork.GLTran.Remove(existingGLTranHeader);
            }

            existingGLTranHeader.datBatchDate = updatedPurchase.TransactionDate;

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(updatedPurchase.Description);
            productDetailsBuilder.AppendLine("( " + updatedPurchase.AdditionalDescription + " )");

            existingGLTranHeader.strDescription = productDetailsBuilder.ToString();
            existingGLTranHeader.blnUseDefaultEntry = UseDefaultEntry;
            existingGLTranHeader.strTransactionCode = updatedPurchase.TRANo;

            // Re-insert the GLTran entries for the purchase
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
                        curDebit = updatedPurchase.Total.Value,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    },
                  new tblGLTranDetail
                    {
                        intIDMasCoa = (int)journalEntry2.intIDMasCOA,
                        intIDMasCoaSub = journalEntry2.ID,
                        curCredit = updatedPurchase.Total.Value,
                        curDebit = 0,
                        intIDGLTranHeader = existingGLTranHeader.ID
                    }

                    //CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, updatedPurchase.Total.Value),
                    //CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, updatedPurchase.Total.Value, 0)
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
                //AddCustomGLTran(unitOfWork, updatedPurchase, tblGLTranDetail);
            }
        }



    }
}
