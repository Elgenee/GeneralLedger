using System;
using System.Collections.Generic;
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
        public Purchase Add(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Purchase.Add(purchase);

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    intIdPurchase = purchase.Id,
                    intIdPurchaseSupplierLedgerTransactionType = 1,
                    TotalAmount = purchase.Total,
                    TransactionDate = purchase.TransactionDate,
                    TransactionNo = purchase.TRANo,
                    DateInserted = DateTime.Now
                };

                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);

                if (UseDefaultEntry)
                {
             
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

                    var gLTranDetail = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = 0,
                             curDebit = purchase.Total
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = purchase.Total,
                             curDebit = 0
                         }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 9,
                        //strTransactionCode = "SAL-" + sale.Id,
                        strDescription = purchase.Description,
                        datBatchDate = purchase.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdPurchase = purchase.Id,
                        blnUseDefaultEntry = UseDefaultEntry
                    };

                    unitOfWork.GLTran.Add(gLTranHeader);
                }
                else
                {
                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 9,
                        //strTransactionCode = "SAL-" + sale.Id,
                        strDescription = purchase.Description,
                        datBatchDate = purchase.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdPurchase = purchase.Id,
                        blnUseDefaultEntry = UseDefaultEntry
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
                //var result = unitOfWork.GLTran.GetGLEntryById(9030);
                unitOfWork.Complete();
                return purchase;
            }
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

        public Purchase Update(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultPurchase = unitOfWork.Purchase.GetPurchasesWithJournalEntry(purchase.Id).SingleOrDefault();
                resultPurchase.PONo = purchase.PONo;
                resultPurchase.SIDR = purchase.SIDR;
                resultPurchase.TRANo = purchase.TRANo;
                resultPurchase.intIDSupplier = purchase.intIDSupplier;
                resultPurchase.Total = purchase.Total;
                resultPurchase.TransactionDate = purchase.TransactionDate;
                resultPurchase.Description = purchase.Description;
                resultPurchase.tblGLTranHeaders.ToList()[0].strDescription = purchase.Description;
                resultPurchase.tblGLTranHeaders.ToList()[0].datBatchDate = purchase.TransactionDate;

                var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPurchase == purchase.Id && p.intIdPurchaseSupplierLedgerTransactionType == 1).SingleOrDefault();
                purchaseLedger.TotalAmount = purchase.Total;
                purchaseLedger.TransactionDate = purchase.TransactionDate;
                purchaseLedger.TransactionNo = purchase.TRANo;

                unitOfWork.GLTranDetail.RemoveRange(resultPurchase.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = 0,
                             curDebit = purchase.Total
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = purchase.Total,
                             curDebit = 0
                         }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultPurchase.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }
                }
                else
                {
                    foreach (var item in tblGLTranDetail)
                    {
                        resultPurchase.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub
                        });
                    }
                }

                resultPurchase.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultPurchase.tblGLTranHeaders.ToList()[0].strDescription = resultPurchase.Description;
                resultPurchase.tblGLTranHeaders.ToList()[0].curCreditAmount = resultPurchase.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultPurchase.tblGLTranHeaders.ToList()[0].curDebitAmount = resultPurchase.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultPurchase;
            }
        }
    }
}
