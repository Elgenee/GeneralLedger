using System;
using System.Collections;
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
    public class PurchaseServices : IPurchaseServices
    {
        public Purchase Add(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> PurchaseDetailsList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                AddPurchaseDetails(purchase, PurchaseDetailsList, unitOfWork);
                unitOfWork.Purchase.Add(purchase);
                UpdateRemainingCount(unitOfWork,purchase, PurchaseDetailsList);
                AddPurchaseSupplierLedger(unitOfWork, purchase);
                AddGLTran(unitOfWork, purchase, tblGLTranDetail, UseDefaultEntry);
                unitOfWork.Complete();
                return purchase;
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
                //TODO: here minus the last updated Product
                    product.intRemainingCount = GetTotalRemainingStock(unitOfWork , productID, newStocks);
                   
                   
                }
        }

        private void AddPurchaseDetails(Purchase purchase, List<PurchaseDetail> PurchaseDetailsList, UnitOfWork unitOfWork)
        {
            foreach (var item in PurchaseDetailsList)
            {
                purchase.PurchaseDetails.Add(new PurchaseDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice
              
                });

                purchase.Stocks.Add(new Stock
                {

                    ProductId = item.ProductId,
                    QuantityIn = item.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 1,
                    PurchaseID = purchase.Id
                });

                //unitOfWork.Stock.Add(new Stock
                //{
                    
                //    ProductId = item.ProductId,
                //    QuantityIn = item.Quantity,
                //    QuantityOut = 0,
                //    StockTransactionTypeID = 1,
                //    PurchaseID = purchase.Id
                //});
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
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, purchase.Total.Value, 0)
            };

 
              AddGLTranHeader(unitOfWork, purchase, gLTranDetail);
        }

        private void AddCustomGLTran(UnitOfWork unitOfWork, Purchase purchase, List<tblGLTranDetail> tblGLTranDetail)
        {
            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 9,
                strDescription = purchase.Description,
                datBatchDate = purchase.TransactionDate,
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
            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 9,
                strDescription = purchase.Description,
                datBatchDate = purchase.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdPurchase = purchase.Id,
                blnUseDefaultEntry = true
            };
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
            throw new NotImplementedException();
        }

        public void Remove(Purchase purchase)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultPurchase = unitOfWork.Purchase.GetPurchasesWithJournalEntry(purchase.Id).SingleOrDefault();
                var tblGlTranDetails = resultPurchase.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultPurchase.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPurchase == purchase.Id && p.intIdPurchaseSupplierLedgerTransactionType == 1).SingleOrDefault();
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseLedger);
                unitOfWork.Purchase.Remove(resultPurchase);
                unitOfWork.Complete();
            }
        }

        public Purchase Update(Purchase updatedPurchase, List<tblGLTranDetail> updatedTblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> updatedPurchaseDetailsList)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
                {
                    // 1. Update purchase details and associated stock records
                    UpdatePurchaseDetails(updatedPurchase, updatedPurchaseDetailsList, unitOfWork);

                    // 2. Update purchase record in the repository
                    var pur = unitOfWork.Purchase.Get(updatedPurchase.Id);
                    pur.PONo = updatedPurchase.PONo;
                    pur.SIDR = updatedPurchase.SIDR;
                    pur.TRANo = updatedPurchase.TRANo;
                    pur.intIDSupplier = updatedPurchase.intIDSupplier;
                    pur.Total = updatedPurchase.Total;
                    pur.TransactionDate = updatedPurchase.TransactionDate;
                    pur.Description = updatedPurchase.Description;

                    pur.PurchaseDetails = updatedPurchase.PurchaseDetails;
                    pur.Stocks = updatedPurchase.Stocks;
                    // 3. Update remaining stock count for products in purchase details
                    UpdateRemainingCount(unitOfWork, updatedPurchase, updatedPurchaseDetailsList);

                    // 4. Update purchase supplier ledger record
                    UpdatePurchaseSupplierLedger(unitOfWork, updatedPurchase);

                    //// 5. Update general ledger transaction records
                    UpdateGLTran(unitOfWork, updatedPurchase, updatedTblGLTranDetail, UseDefaultEntry);

                    // 6. Commit changes to the database
                    unitOfWork.Complete();

                    return updatedPurchase;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }


        private void UpdatePurchaseDetails(Purchase updatedPurchase, List<PurchaseDetail> updatedPurchaseDetailsList, UnitOfWork unitOfWork)
        {
            // Delete existing purchase details and stock records
            foreach (var existingDetail in updatedPurchase.PurchaseDetails.ToList())
            {
                var purchaseDetailExist = unitOfWork.PurchaseDetail.Get(existingDetail.Id);
                unitOfWork.PurchaseDetail.Remove(purchaseDetailExist);
                //var existingStock = updatedPurchase.Stocks.FirstOrDefault(s => s.ProductId == existingDetail.ProductId);

                var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.PurchaseID == existingDetail.PurchaseId).FirstOrDefault();
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
            updatedPurchase.PurchaseDetails.Clear();
            updatedPurchase.Stocks.Clear();

            // Add new purchase details and stock records
            foreach (var updatedDetail in updatedPurchaseDetailsList)
            {
                updatedPurchase.PurchaseDetails.Add(new PurchaseDetail
                {
                    //PurchaseId = updatedDetail.Id,
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice
                });

                updatedPurchase.Stocks.Add(new Stock
                {
                    ProductId = updatedDetail.ProductId,
                    QuantityIn = updatedDetail.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 1
                    //PurchaseID = updatedPurchase.Id
                });
            }
        }

        private void UpdatePurchaseSupplierLedger(UnitOfWork unitOfWork, Purchase updatedPurchase)
        {
            // Find and delete existing purchase supplier ledger record
            var existingPurchaseSupplierLedger = unitOfWork.PurchaseSupplierLedger.Find(psl => psl.intIdPurchase == updatedPurchase.Id).SingleOrDefault();
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


        private void UpdateGLTran(UnitOfWork unitOfWork, Purchase updatedPurchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            // Delete existing GLTran entries for the purchase
            var existingGLTranHeader = unitOfWork.GLTran.Find(h => h.intIdPurchase == updatedPurchase.Id).SingleOrDefault();
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
            existingGLTranHeader.strDescription = updatedPurchase.Description;
            existingGLTranHeader.blnUseDefaultEntry = UseDefaultEntry;

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
