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
        public Purchase Add(Purchase purchase)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Purchase.Add(purchase);

                var purchaseCustomerLedger = new PurchaseCustomerLedger
                {
                    intIdPurchase = purchase.Id,
                    intIdPurchaseCustomerLedgerTransactionType = 1,
                    TotalAmount = purchase.Total,
                    TransactionDate = purchase.TransactionDate,
                    TransactionNo = purchase.TRANo,
                    DateInserted = DateTime.Now
                };

               unitOfWork.PurchaseCustomerLedger.Add(purchaseCustomerLedger);

                var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

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
                    intIDGLBookType = 2007,
                    //strTransactionCode = "SAL-" + sale.Id,
                    datBatchDate = purchase.TransactionDate,
                    datInsertedDate = DateTime.Now,
                    tblGLTranDetails = gLTranDetail,
                    intIdPurchase = purchase.Id
                };

                unitOfWork.GLTran.Add(gLTranHeader);
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
            throw new NotImplementedException();
        }

        public Purchase GetPurchaseWithSupplier(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public Purchase Update(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail)
        {
            throw new NotImplementedException();
        }
    }
}
