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
    public class PaymentServices : IPaymentServices
    {
        public Payment Add(Payment payment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {

            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Payment.Add(payment);

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    intIdPurchase = payment.PurchaseId,
                    intIdPayment = payment.Id,
                    intIdPurchaseSupplierLedgerTransactionType = 2,
                    TotalAmount = payment.PaymentTotal,
                    TransactionDate = payment.PaymentTransactionDate,
                    TransactionNo = payment.PaymentCV,
                    DateInserted = DateTime.Now
                };

                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);

                var paySum = unitOfWork.PurchaseSupplierLedger
                    .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
                s.intIdPurchaseSupplierLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                paySum += purchaseCustomerLedger.TotalAmount;

                var adjSum = unitOfWork.PurchaseSupplierLedger
                   .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
               s.intIdPurchaseSupplierLedgerTransactionType == 3).Sum(s => s.TotalAmount);

                var purchase = unitOfWork.Purchase.Get((int) purchaseCustomerLedger.intIdPurchase);

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
                         curCredit = 0,
                         curDebit = payment.PaymentTotal
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  payment.PaymentTotal,
                         curDebit = 0
                     }
                    };


                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 10,
                        datBatchDate = payment.PaymentTransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdPayment = payment.Id,
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
                        intIDGLBookType = 10,
                        datBatchDate = payment.PaymentTransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdPayment = payment.Id,
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

                unitOfWork.Complete();
                return payment;
            }
        }

        public List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentWithPurchaseBank(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Payment.GetPaymentWithPurchaseBank(criteria).ToList();
            }
        }

        public void Remove(Payment payment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultPayment = unitOfWork.Payment.GetPaymentWithJournalEntry(payment.Id).SingleOrDefault();
                var tblGlTranDetails = resultPayment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultPayment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPayment == payment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 2).SingleOrDefault();
                unitOfWork.PurchaseSupplierLedger.Remove(purchaseLedger);

                var paySumList = unitOfWork.PurchaseSupplierLedger
                   .Find(s => s.intIdPurchase == purchaseLedger.intIdPurchase &&
                    s.intIdPurchaseSupplierLedgerTransactionType == 2).ToList();

                paySumList.Remove(purchaseLedger);

                var paySum = paySumList.Sum(p => p.TotalAmount);

                //change here if naay lain adjustment
                var adjSum = unitOfWork.PurchaseSupplierLedger
                 .Find(s => s.intIdPurchase == purchaseLedger.intIdPurchase &&
                  s.intIdPurchaseSupplierLedgerTransactionType == 3).Sum(s => s.TotalAmount);

                var purchase = unitOfWork.Purchase.Get((int)payment.PurchaseId);


                if (((purchase.Total + adjSum) - paySum) <= 0)
                {
                    purchase.IsFullyPaid = true;
                    purchase.LastPaymentDate = purchaseLedger.TransactionDate;
                }
                else
                {
                    purchase.IsFullyPaid = false;
                    purchase.LastPaymentDate = null;
                }

                unitOfWork.Payment.Remove(resultPayment);
                unitOfWork.Complete();

            }
        }

        public Payment Update(Payment payment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultPayment = unitOfWork.Payment.GetPaymentWithJournalEntry(payment.Id).SingleOrDefault();
                resultPayment.PaymentCV = payment.PaymentCV;
                resultPayment.PaymentSIDR = payment.PaymentSIDR;
                resultPayment.PaymentTransactionDate = payment.PaymentTransactionDate;
                resultPayment.PaymentTotal = payment.PaymentTotal;
                resultPayment.PaymentIsCash = payment.PaymentIsCash;
                resultPayment.PurchaseId = payment.PurchaseId;
                resultPayment.PaymentBankId = payment.PaymentBankId;
                resultPayment.PaymentCheckDetail = payment.PaymentCheckDetail;

                var purchaseLedger = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdPayment == payment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 2).SingleOrDefault();
                purchaseLedger.TotalAmount = payment.PaymentTotal;
                purchaseLedger.TransactionDate = payment.PaymentTransactionDate;
                purchaseLedger.TransactionNo = payment.PaymentCV;


                var paySum = unitOfWork.PurchaseSupplierLedger
                    .Find(s => s.intIdPurchase == purchaseLedger.intIdPurchase &&
                s.intIdPurchaseSupplierLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                var adjSum = unitOfWork.PurchaseSupplierLedger
                   .Find(s => s.intIdPurchase == purchaseLedger.intIdPurchase &&
               s.intIdPurchaseSupplierLedgerTransactionType == 3).Sum(s => s.TotalAmount);

                var purchase = unitOfWork.Purchase.Get((int)purchaseLedger.intIdPurchase);

                if (((purchase.Total + adjSum) - paySum) <= 0)
                {
                    purchase.IsFullyPaid = true;
                    purchase.LastPaymentDate = purchaseLedger.TransactionDate;
                }
                else
                {
                    purchase.IsFullyPaid = false;
                    purchase.LastPaymentDate = null;
                }

                unitOfWork.GLTranDetail.RemoveRange(resultPayment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());


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
                         curCredit = 0,
                         curDebit = payment.PaymentTotal
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  payment.PaymentTotal,
                         curDebit = 0
                     }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultPayment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultPayment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }
                }

                resultPayment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultPayment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultPayment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultPayment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultPayment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultPayment;
            }
        }
    }
}
