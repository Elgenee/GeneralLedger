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

                var purchaseCustomerLedger = new PurchaseCustomerLedger
                {
                    intIdPurchase = payment.PurchaseId,
                    intIdPayment = payment.Id,
                    intIdPurchaseCustomerLedgerTransactionType = 2,
                    TotalAmount = payment.PaymentTotal,
                    TransactionDate = payment.PaymentTransactionDate,
                    TransactionNo = payment.PaymentCV,
                    DateInserted = DateTime.Now
                };

                unitOfWork.PurchaseCustomerLedger.Add(purchaseCustomerLedger);

                var paySum = unitOfWork.PurchaseCustomerLedger
                    .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
                s.intIdPurchaseCustomerLedgerTransactionType == 2).Sum(s => s.TotalAmount);

                paySum += purchaseCustomerLedger.TotalAmount;

                var adjSum = unitOfWork.PurchaseCustomerLedger
                   .Find(s => s.intIdPurchase == purchaseCustomerLedger.intIdPurchase &&
               s.intIdPurchaseCustomerLedgerTransactionType == 3).Sum(s => s.TotalAmount);

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
            throw new NotImplementedException();
        }

        public Payment Update(Payment payment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            throw new NotImplementedException();
        }
    }
}
