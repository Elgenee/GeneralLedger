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
    public class CollectionServices : ICollectionServices
    {
        public Collection Add(Collection collection, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {

            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Collection.Add(collection);

                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = collection.SalesId,
                    intIdCollection = collection.Id,
                    intIdSalesCustomerLedgerTransctionType = 2,
                    TotalAmount = collection.Total,
                    TransactionDate = collection.TransactionDate,
                    TransactionNo = collection.TRANo,
                    DateInserted = DateTime.Now
                };

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);

                var collSum = unitOfWork.SalesCustomerLedger
                    .Find(s => s.intIdSales == salesCustomerLedger.intIdSales &&
                        s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);

                collSum += salesCustomerLedger.TotalAmount;
                var sale = unitOfWork.Sale.Get((int)salesCustomerLedger.intIdSales);

                if ((sale.Total - collSum) <= 0)
                    sale.IsFullyPaid = true;
                else
                    sale.IsFullyPaid = false;

                if (UseDefaultEntry)
                {
                    tblMasCOASub journalEntry1;

                    //if ((bool)collection.IsCash)
                    //    journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1022).SingleOrDefault();
                    //else
                    //    journalEntry1 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();
                    journalEntry1 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

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
                        intIDGLBookType = 7,
                        datBatchDate = collection.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdCollection = collection.Id,
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
                        intIDGLBookType = 7,
                        datBatchDate = collection.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = tblGLTranDetail,
                        intIdCollection = collection.Id
                    };
                    unitOfWork.GLTran.Add(gLTranHeader);
                }
                unitOfWork.Complete();
                return collection;
            }
        }

        public List<Collection> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Collection> GetCollectionWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Collection> GetCollectionWithSaleBank(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Collection.GetCollectionWithSaleBank(criteria).ToList();

            }
        }

  
        public void Remove(Collection collection)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultCollection = unitOfWork.Collection.GetCollectionWithJournalEntry(collection.Id).SingleOrDefault();
                var tblGlTranDetails = resultCollection.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultCollection.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdCollection == collection.Id && s.intIdSalesCustomerLedgerTransctionType == 2).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);

                //var collSum = unitOfWork.SalesCustomerLedger
                // .Find(s => s.intIdSales == collection.SalesId &&
                //     s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);
                var collSumList = unitOfWork.SalesCustomerLedger
                 .Find(s => s.intIdSales == collection.SalesId &&
                     s.intIdSalesCustomerLedgerTransctionType == 2).ToList();

                collSumList.Remove(salesLedger);

                var collSum = collSumList.Sum(s => s.TotalAmount);

                var sale = unitOfWork.Sale.Get((int)collection.SalesId);

                if ((sale.Total - collSum) <= 0)
                    sale.IsFullyPaid = true;
                else
                    sale.IsFullyPaid = false;

                unitOfWork.Collection.Remove(resultCollection);
                unitOfWork.Complete();
            }
        }

        public Collection Update(Collection collection, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultCollection = unitOfWork.Collection.GetCollectionWithJournalEntry(collection.Id).SingleOrDefault();
                resultCollection.TRANo = collection.TRANo;
                resultCollection.Total = collection.Total;
                resultCollection.TransactionDate = collection.TransactionDate;
                resultCollection.Description = collection.Description;
                resultCollection.SalesId = collection.SalesId;
                resultCollection.BankId = collection.BankId;
                resultCollection.CheckDetail = collection.CheckDetail;
                resultCollection.IsCash = collection.IsCash;
                resultCollection.tblGLTranHeaders.ToList()[0].strDescription = collection.Description;
                resultCollection.tblGLTranHeaders.ToList()[0].datBatchDate = collection.TransactionDate;

                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdCollection == collection.Id && s.intIdSalesCustomerLedgerTransctionType == 2).SingleOrDefault();
                salesLedger.TotalAmount = collection.Total;
                salesLedger.TransactionDate = collection.TransactionDate;
                salesLedger.TransactionNo = collection.TRANo;

                var collSum = unitOfWork.SalesCustomerLedger
                    .Find(s => s.intIdSales == salesLedger.intIdSales &&
                        s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);

                var sale = unitOfWork.Sale.Get((int)salesLedger.intIdSales);

                if ((sale.Total - collSum) <= 0)
                    sale.IsFullyPaid = true;
                else
                    sale.IsFullyPaid = false;


                unitOfWork.GLTranDetail.RemoveRange(resultCollection.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    tblMasCOASub journalEntry1;

                    //if ((bool)collection.IsCash)
                    //    journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1022).SingleOrDefault();
                    //else
                    //    journalEntry1 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();
                    journalEntry1 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
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

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultCollection.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultCollection.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }

                }
                resultCollection.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultCollection.tblGLTranHeaders.ToList()[0].curCreditAmount = resultCollection.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultCollection.tblGLTranHeaders.ToList()[0].curDebitAmount = resultCollection.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultCollection;
            }
        }
    }
}
