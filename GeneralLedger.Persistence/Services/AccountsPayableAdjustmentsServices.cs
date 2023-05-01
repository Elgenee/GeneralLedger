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
    public class AccountsPayableAdjustmentsServices : IAccountsPayableAdjustmentsServices
    {
        public AccountPayableAdjustment AddDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {

                //var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                unitOfWork.AccountsPayableAdjustments.Add(accountPayableAdjustment);

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    //intIdPurchase = accountPayableAdjustment.PurchaseId,
                    //intIdPayment = payment.Id,
                    intIdSupplier = accountPayableAdjustment.SupplierId,
                    intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                    intIdPurchaseSupplierLedgerTransactionType = 3,
                    TotalAmount = accountPayableAdjustment.TotalAmount,
                    TransactionDate = accountPayableAdjustment.TransactionDate,
                    TransactionNo = accountPayableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {

                    var gLTranDetail = new List<tblGLTranDetail>();
                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        strDescription = accountPayableAdjustment.Description,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = gLTranDetail,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                        blnUseDefaultEntry = UseDefaultEntry
                    };

                    foreach (var item in gLTranDetail)
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
                else
                {

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
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

                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);
                unitOfWork.Complete();
                return accountPayableAdjustment;
            }
        }

        public AccountPayableAdjustment AddReturnPayment(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.AccountsPayableAdjustments.Add(accountPayableAdjustment);
                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                var payment = unitOfWork.Payment.Get((int)accountPayableAdjustment.PaymentId);

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    intIdPurchase = payment.PurchaseId,
                    //intIdPayment = payment.Id,
                    intIdSupplier = purchase.intIDSupplier,
                    intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                    intIdPurchaseSupplierLedgerTransactionType = 3,
                    TotalAmount = payment.PaymentTotal,
                    TransactionDate = accountPayableAdjustment.TransactionDate,
                    TransactionNo = accountPayableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {
                    tblMasCOASub journalEntry1;
                    journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault();

                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == payment.PaymentBankId).SingleOrDefault();

                    var gLTranDetail = new List<tblGLTranDetail>
                    {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = payment.PaymentTotal,
                         curDebit = 0
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  0,
                         curDebit = payment.PaymentTotal
                     }
                    };


                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        datBatchDate = payment.PaymentTransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
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
                        intIDGLBookType = 11,
                        datBatchDate = payment.PaymentTransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        //intIdPayment = payment.Id,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
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

                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);

                var paySum = unitOfWork.PurchaseSupplierLedger
                    .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
                s.intIdPurchaseSupplierLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                var adjSum = unitOfWork.PurchaseSupplierLedger
                   .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
               s.intIdPurchaseSupplierLedgerTransactionType == 3 && s.AccountPayableAdjustment.AccountsPayableAdjustmentTypeId == 1).Sum(s => s.TotalAmount);

                adjSum += purchaseCustomerLedger.TotalAmount;

                if (((purchase.Total + adjSum) - paySum) <= 0)
                {
                    purchase.IsFullyPaid = true;
                    purchase.LastPaymentDate = purchaseCustomerLedger.TransactionDate;
                }
                else
                {
                    purchase.IsFullyPaid = false;
                    purchase.LastPaymentDate = null;
                }

                unitOfWork.Complete();
                return accountPayableAdjustment;
            }
        }

        public AccountPayableAdjustment AddReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
     
                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                unitOfWork.AccountsPayableAdjustments.Add(accountPayableAdjustment);

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    intIdPurchase = accountPayableAdjustment.PurchaseId,
                    //intIdPayment = payment.Id,
                    intIdSupplier = purchase.intIDSupplier,
                    intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                    intIdPurchaseSupplierLedgerTransactionType = 3,
                    TotalAmount = accountPayableAdjustment.TotalAmount,
                    TransactionDate = accountPayableAdjustment.TransactionDate,
                    TransactionNo = accountPayableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

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
                             curCredit = purchase.Total ,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = purchase.Total 
                         }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = gLTranDetail,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                        blnUseDefaultEntry = UseDefaultEntry
                    };

                    foreach (var item in gLTranDetail)
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
                else
                {

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
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

                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);
                purchase.IsPurchaseReturn = true;
                unitOfWork.Complete();
                return accountPayableAdjustment;
            }
        }

        public List<AccountPayableAdjustment> GetAccountPayableAdjustmentsDMCM(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsDMCM(criteria).ToList();

            }
        }

        public List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPaymentPurchases(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithPaymentPurchases(criteria, intIdAccountsPayableAdjustmentsType).ToList();

            }
        }

        public List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPurchases(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithPurchases(criteria, intIdAccountsPayableAdjustmentsType).ToList();

            }
        }

        public List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithSupplier(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            throw new NotImplementedException();
        }

        public List<AccountPayableAdjustment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAccountPayableAdjustment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseCustomerLedger);
                unitOfWork.AccountsPayableAdjustments.Remove(resultAccountPayableAdjustment);
                unitOfWork.Complete();
            }
        }

        //TODO:Remove Return Payment
        public void RemoveReturnPayment(AccountPayableAdjustment accountPayableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAccountPayableAdjustment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseCustomerLedger);

                var adjSumList = unitOfWork.PurchaseSupplierLedger
                .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
                s.intIdPurchaseSupplierLedgerTransactionType == 3 && s.AccountPayableAdjustment.AccountsPayableAdjustmentTypeId == 1).ToList();

                adjSumList.Remove(purchaseCustomerLedger);

                var adjSum = adjSumList.Sum(a => a.TotalAmount);

                var paySum = unitOfWork.PurchaseSupplierLedger
                .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase && s.intIdPurchaseSupplierLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);


                if (((purchase.Total + adjSum) - paySum) <= 0)
                {
                    purchase.IsFullyPaid = true;
                    purchase.LastPaymentDate = purchaseCustomerLedger.TransactionDate;
                }
                else
                {
                    purchase.IsFullyPaid = false;
                    purchase.LastPaymentDate = null;
                }


                unitOfWork.AccountsPayableAdjustments.Remove(resultAccountPayableAdjustment);
                unitOfWork.Complete();

            }
        }

        public void RemoveReturnPurchases(AccountPayableAdjustment accountPayableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAccountPayableAdjustment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseCustomerLedger);

                var adjSumList = unitOfWork.PurchaseSupplierLedger
                .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
                s.intIdPurchaseSupplierLedgerTransactionType == 3 && s.AccountPayableAdjustment.AccountsPayableAdjustmentTypeId == 1).ToList();

                adjSumList.Remove(purchaseCustomerLedger);
                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);

                purchase.IsPurchaseReturn = false;

                unitOfWork.AccountsPayableAdjustments.Remove(resultAccountPayableAdjustment);
                unitOfWork.Complete();



            }
        }

        public AccountPayableAdjustment UpdateDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                resultAccountPayableAdjustment.AccountsPayableAdjustmentTypeId = accountPayableAdjustment.AccountsPayableAdjustmentTypeId;
                resultAccountPayableAdjustment.TransactionNo = accountPayableAdjustment.TransactionNo;
                resultAccountPayableAdjustment.TransactionDate = accountPayableAdjustment.TransactionDate;
                //resultAccountPayableAdjustment.PaymentId = accountPayableAdjustment.PaymentId;
                resultAccountPayableAdjustment.Description = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.SupplierId = accountPayableAdjustment.SupplierId;
                resultAccountPayableAdjustment.TotalAmount = accountPayableAdjustment.TotalAmount;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].strDescription = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].datBatchDate = accountPayableAdjustment.TransactionDate;

                //var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                //var payment = unitOfWork.Payment.Get((int)accountPayableAdjustment.PaymentId);

                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                //purchaseCustomerLedger.intIdPurchase = resultAccountPayableAdjustment.PurchaseId;
                purchaseCustomerLedger.intIdSupplier = accountPayableAdjustment.SupplierId;
                purchaseCustomerLedger.intIdAccountPayableAdjustment = accountPayableAdjustment.Id;
                purchaseCustomerLedger.TotalAmount = resultAccountPayableAdjustment.TotalAmount;
                purchaseCustomerLedger.TransactionDate = accountPayableAdjustment.TransactionDate;
                purchaseCustomerLedger.TransactionNo = accountPayableAdjustment.TransactionNo;
                purchaseCustomerLedger.DateInserted = DateTime.Now;
                //purchase.IsPurchaseReturn = true;

                unitOfWork.GLTranDetail.RemoveRange(resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {
                    var gLTranDetailDefault = new List<tblGLTranDetail>();
                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }

                }

                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAccountPayableAdjustment;
            }
        }

        public AccountPayableAdjustment UpdateReturnPayment(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                resultAccountPayableAdjustment.AccountsPayableAdjustmentTypeId = accountPayableAdjustment.AccountsPayableAdjustmentTypeId;
                resultAccountPayableAdjustment.TransactionNo = accountPayableAdjustment.TransactionNo;
                resultAccountPayableAdjustment.TransactionDate = accountPayableAdjustment.TransactionDate;
                resultAccountPayableAdjustment.PaymentId = accountPayableAdjustment.PaymentId;
                resultAccountPayableAdjustment.Description = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.PurchaseId = accountPayableAdjustment.PurchaseId;
                resultAccountPayableAdjustment.TotalAmount = accountPayableAdjustment.TotalAmount;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].strDescription = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].datBatchDate = accountPayableAdjustment.TransactionDate;

                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                var payment = unitOfWork.Payment.Get((int)accountPayableAdjustment.PaymentId);

                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                purchaseCustomerLedger.intIdPurchase = payment.PurchaseId;
                purchaseCustomerLedger.intIdSupplier = purchase.intIDSupplier;
                purchaseCustomerLedger.intIdAccountPayableAdjustment = accountPayableAdjustment.Id;
                purchaseCustomerLedger.TotalAmount = payment.PaymentTotal;
                purchaseCustomerLedger.TransactionDate = accountPayableAdjustment.TransactionDate;
                purchaseCustomerLedger.TransactionNo = accountPayableAdjustment.TransactionNo;
                purchaseCustomerLedger.DateInserted = DateTime.Now;

                var paySum = unitOfWork.PurchaseSupplierLedger
                    .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase && s.intIdPurchaseSupplierLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                var adjSum = unitOfWork.PurchaseSupplierLedger
                   .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
               s.intIdPurchaseSupplierLedgerTransactionType == 3 && s.AccountPayableAdjustment.AccountsPayableAdjustmentTypeId == 1).Sum(s => s.TotalAmount);

                adjSum += purchaseCustomerLedger.TotalAmount;

                if (((purchase.Total + adjSum) - paySum) <= 0)
                {
                    purchase.IsFullyPaid = true;
                    purchase.LastPaymentDate = purchaseCustomerLedger.TransactionDate;
                }
                else
                {
                    purchase.IsFullyPaid = false;
                    purchase.LastPaymentDate = null;
                }

                unitOfWork.GLTranDetail.RemoveRange(resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {
                    tblMasCOASub journalEntry1;
                    journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault();

                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == payment.PaymentBankId).SingleOrDefault();

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = payment.PaymentTotal,
                         curDebit = 0
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  0,
                         curDebit = payment.PaymentTotal
                     }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }

                }

                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAccountPayableAdjustment;
            }
        }

        public AccountPayableAdjustment UpdateReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();
                resultAccountPayableAdjustment.AccountsPayableAdjustmentTypeId = accountPayableAdjustment.AccountsPayableAdjustmentTypeId;
                resultAccountPayableAdjustment.TransactionNo = accountPayableAdjustment.TransactionNo;
                resultAccountPayableAdjustment.TransactionDate = accountPayableAdjustment.TransactionDate;
                //resultAccountPayableAdjustment.PaymentId = accountPayableAdjustment.PaymentId;
                resultAccountPayableAdjustment.Description = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.PurchaseId = accountPayableAdjustment.PurchaseId;
                resultAccountPayableAdjustment.TotalAmount = accountPayableAdjustment.TotalAmount;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].strDescription = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].datBatchDate = accountPayableAdjustment.TransactionDate;

                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                //var payment = unitOfWork.Payment.Get((int)accountPayableAdjustment.PaymentId);

                var purchaseCustomerLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();
                purchaseCustomerLedger.intIdPurchase = resultAccountPayableAdjustment.PurchaseId;
                purchaseCustomerLedger.intIdSupplier = purchase.intIDSupplier;
                purchaseCustomerLedger.intIdAccountPayableAdjustment = accountPayableAdjustment.Id;
                purchaseCustomerLedger.TotalAmount = resultAccountPayableAdjustment.TotalAmount;
                purchaseCustomerLedger.TransactionDate = accountPayableAdjustment.TransactionDate;
                purchaseCustomerLedger.TransactionNo = accountPayableAdjustment.TransactionNo;
                purchaseCustomerLedger.DateInserted = DateTime.Now;
                purchase.IsPurchaseReturn = true;

                unitOfWork.GLTranDetail.RemoveRange(resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

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
                             curCredit = purchase.Total ,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = purchase.Total
                         }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }

                }

                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAccountPayableAdjustment;
            }
        }
    }
}
