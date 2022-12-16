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
    public class AccountReceivableAdjustmentsServices : IAccountReceivableAdjustmentsServices
    {

        //TODO:here adding accountReceivableAdjusmnt
        public AccountReceivableAdjustment Add(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.AccountsReceivableAdjustments.Add(accountReceivableAdjustment);

                var collection = unitOfWork.Collection.Get((int)accountReceivableAdjustment.CollectionId);

                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = accountReceivableAdjustment.SalesId,
                    //intIdCollection = accountReceivableAdjustment.Id,
                    intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    intIdSalesCustomerLedgerTransctionType = 3,
                    TotalAmount = collection.Total,
                    TransactionDate = accountReceivableAdjustment.TransactionDate,
                    TransactionNo = accountReceivableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    
                    tblMasCOASub journalEntry2;
                    if ((bool)collection.IsCash)
                        journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1022).SingleOrDefault();
                    else
                        journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                 

                    var gLTranDetail = new List<tblGLTranDetail>
                    {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = 0,
                         curDebit = collection.Total
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  collection.Total,
                         curDebit = 0
                     }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 8,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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
                        intIDGLBookType = 8,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = tblGLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    };
                    unitOfWork.GLTran.Add(gLTranHeader);
                }

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);
                unitOfWork.Complete();
                return accountReceivableAdjustment;
            }
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria)
        {
            throw new NotImplementedException();
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<AccountReceivableAdjustment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(AccountReceivableAdjustment accountReceivableAdjustment)
        {
            throw new NotImplementedException();
        }

        public AccountReceivableAdjustment Update(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            throw new NotImplementedException();
        }
    }
}
