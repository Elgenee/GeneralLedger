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

        public AccountReceivableAdjustment AddReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.AccountsReceivableAdjustments.Add(accountReceivableAdjustment);

                var collection = unitOfWork.Collection.Get((int)accountReceivableAdjustment.CollectionId);
                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);

                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = accountReceivableAdjustment.SalesId,
                    intIdCustomer = sales.intIdCustomer,
                    //intIdCollection = accountReceivableAdjustment.Id,
                    intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    intIdSalesCustomerLedgerTransctionType = 3,
                    TotalAmount = accountReceivableAdjustment.TotalAmount,
                    TransactionDate = accountReceivableAdjustment.TransactionDate,
                    TransactionNo = accountReceivableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

                    tblMasCOASub journalEntry2;
                    //if ((bool)collection.IsCash)
                    //    journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1022).SingleOrDefault();
                    //else
                    //    journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    var gLTranDetail = new List<tblGLTranDetail>
                    {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = 0,
                         curDebit = accountReceivableAdjustment.TotalAmount
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit =  accountReceivableAdjustment.TotalAmount,
                         curDebit = 0
                     }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 8,
                        strDescription = accountReceivableAdjustment.Descrpition,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = gLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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
                        intIDGLBookType = 8,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);

                var collSum = unitOfWork.SalesCustomerLedger
                 .Find(s => s.intIdSales == salesCustomerLedger.intIdSales &&
                     s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);

                var adjSum = unitOfWork.SalesCustomerLedger
                .Find(s => s.intIdSales == salesCustomerLedger.intIdSales &&
                    s.intIdSalesCustomerLedgerTransctionType == 3 && s.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId == 1).Sum(s => s.TotalAmount);

                adjSum += salesCustomerLedger.TotalAmount;

                var sale = unitOfWork.Sale.Get((int)salesCustomerLedger.intIdSales);

                if (((sale.Total + adjSum) - collSum) <= 0)
                {
                    sale.IsFullyPaid = true;
                    sale.LastPaymentDate = salesCustomerLedger.TransactionDate;
                }
                else
                {
                    sale.IsFullyPaid = false;
                    sale.LastPaymentDate = null;
                }
                unitOfWork.Complete();
                return accountReceivableAdjustment;
            }
        }

        public AccountReceivableAdjustment AddReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);
                unitOfWork.AccountsReceivableAdjustments.Add(accountReceivableAdjustment);
            
                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = accountReceivableAdjustment.SalesId,
                    intIdCustomer = sales.intIdCustomer,
                    //intIdCollection = accountReceivableAdjustment.Id,
                    intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    intIdSalesCustomerLedgerTransctionType = 3,
                    TotalAmount = accountReceivableAdjustment.TotalAmount,
                    TransactionDate = accountReceivableAdjustment.TransactionDate,
                    TransactionNo = accountReceivableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
                    var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
                    var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
                    var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

                    var gLTranDetail = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = sales.Total,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = sales.SOPAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry3.ID,
                             curCredit = 0,
                             curDebit = sales.COMMAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry4.ID,
                             curCredit = 0,
                             curDebit =  sales.CFAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry5.ID,
                             curCredit = 0,
                             curDebit = sales.Total - (sales.COMMAmount + sales.SOPAmount + sales.CFAmount)
                         }
                    };


                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 8,
                        strDescription = accountReceivableAdjustment.Descrpition,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = gLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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
                        intIDGLBookType = 8,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);
                sales.IsSalesReturn = true;
                unitOfWork.Complete();
                return accountReceivableAdjustment;
            }
        }


        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        public AccountReceivableAdjustment UpdateReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                resultAdjustmentReceivableAdjusment.AccountsReceivableAdjustmentsTypeId = accountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                resultAdjustmentReceivableAdjusment.TransactionNo = accountReceivableAdjustment.TransactionNo;
                resultAdjustmentReceivableAdjusment.TransactionDate = accountReceivableAdjustment.TransactionDate;
                //resultAdjustmentReceivableAdjusment.CollectionId = accountReceivableAdjustment.CollectionId;
                resultAdjustmentReceivableAdjusment.Descrpition = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.SalesId = accountReceivableAdjustment.SalesId;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].strDescription = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].datBatchDate = accountReceivableAdjustment.TransactionDate;
                resultAdjustmentReceivableAdjusment.TotalAmount = accountReceivableAdjustment.TotalAmount;

                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);

                var salesCustomerLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                salesCustomerLedger.intIdSales = accountReceivableAdjustment.SalesId;
                salesCustomerLedger.intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id;
                salesCustomerLedger.TotalAmount = accountReceivableAdjustment.TotalAmount;
                salesCustomerLedger.TransactionDate = accountReceivableAdjustment.TransactionDate;
                salesCustomerLedger.TransactionNo = accountReceivableAdjustment.TransactionNo;
                salesCustomerLedger.DateInserted = DateTime.Now;
                sales.IsSalesReturn = true;

                unitOfWork.GLTranDetail.RemoveRange(resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
                    var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
                    var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
                    var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = sales.Total,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = sales.SOPAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry3.ID,
                             curCredit = 0,
                             curDebit = sales.COMMAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry4.ID,
                             curCredit = 0,
                             curDebit =  sales.CFAmount
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry5.ID,
                             curCredit = 0,
                             curDebit = sales.Total - (sales.COMMAmount + sales.SOPAmount + sales.CFAmount)
                         }
                    };


                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }
                }

                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAdjustmentReceivableAdjusment;
            }
        }
    
        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria , int intIdAccountsReceivableAdjustmentsType )
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithCollectionSales(criteria, intIdAccountsReceivableAdjustmentsType).ToList();

            }
        }

        public List<AccountReceivableAdjustment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);

                var adjSumList = unitOfWork.SalesCustomerLedger
                .Find(s => s.intIdSales == accountReceivableAdjustment.SalesId &&
                    s.intIdSalesCustomerLedgerTransctionType == 3 && s.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId == 1).ToList();

                adjSumList.Remove(salesLedger);

                var adjSum = adjSumList.Sum(a => a.TotalAmount);

                var collSum = unitOfWork.SalesCustomerLedger
               .Find(s => s.intIdSales == accountReceivableAdjustment.SalesId &&
                   s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);

                var sale = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);


                if (((sale.Total + adjSum) - collSum) <= 0)
                {
                    sale.IsFullyPaid = true;
                    sale.LastPaymentDate = salesLedger.TransactionDate;
                }
                else
                {
                    sale.IsFullyPaid = false;
                    sale.LastPaymentDate = null;
                }


                unitOfWork.AccountsReceivableAdjustments.Remove(resultAdjustmentReceivableAdjusment);
                unitOfWork.Complete();
            }
        }

        public void RemoveReturnSales(AccountReceivableAdjustment accountReceivableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);

                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);
                sales.IsSalesReturn = false;

                unitOfWork.AccountsReceivableAdjustments.Remove(resultAdjustmentReceivableAdjusment);
                unitOfWork.Complete();
            }
        }

        public AccountReceivableAdjustment UpdateReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                resultAdjustmentReceivableAdjusment.AccountsReceivableAdjustmentsTypeId = accountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                resultAdjustmentReceivableAdjusment.TransactionNo = accountReceivableAdjustment.TransactionNo;
                resultAdjustmentReceivableAdjusment.TransactionDate = accountReceivableAdjustment.TransactionDate;
                resultAdjustmentReceivableAdjusment.CollectionId = accountReceivableAdjustment.CollectionId;
                resultAdjustmentReceivableAdjusment.Descrpition = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.SalesId = accountReceivableAdjustment.SalesId;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].strDescription = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].datBatchDate = accountReceivableAdjustment.TransactionDate;
                resultAdjustmentReceivableAdjusment.TotalAmount = accountReceivableAdjustment.TotalAmount;

                var collection = unitOfWork.Collection.Get((int)accountReceivableAdjustment.CollectionId);

                var salesCustomerLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                salesCustomerLedger.intIdSales = accountReceivableAdjustment.SalesId;
                salesCustomerLedger.intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id;
                salesCustomerLedger.TotalAmount = accountReceivableAdjustment.TotalAmount; 
                salesCustomerLedger.TransactionDate = accountReceivableAdjustment.TransactionDate;
                salesCustomerLedger.TransactionNo = accountReceivableAdjustment.TransactionNo;
                salesCustomerLedger.DateInserted = DateTime.Now;


                var collSum = unitOfWork.SalesCustomerLedger
                 .Find(s => s.intIdSales == salesCustomerLedger.intIdSales &&
                     s.intIdSalesCustomerLedgerTransctionType == 2).Sum(s => s.TotalAmount);

                var adjSum = unitOfWork.SalesCustomerLedger
                .Find(s => s.intIdSales == salesCustomerLedger.intIdSales &&
                    s.intIdSalesCustomerLedgerTransctionType == 3 && s.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId == 1).Sum(s => s.TotalAmount);

                var sale = unitOfWork.Sale.Get((int)salesCustomerLedger.intIdSales);

                if (((sale.Total + adjSum) - collSum) <= 0)
                {
                    sale.IsFullyPaid = true;
                    sale.LastPaymentDate = salesCustomerLedger.TransactionDate;
                }
                else
                {
                    sale.IsFullyPaid = false;
                    sale.LastPaymentDate = null;
                }

                unitOfWork.GLTranDetail.RemoveRange(resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

                    tblMasCOASub journalEntry2;
                    //if ((bool)collection.IsCash)
                    //    journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1022).SingleOrDefault();
                    //else
                    //    journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    journalEntry2 = unitOfWork.CoaSub.Find(c => c.intIDBank == collection.BankId).SingleOrDefault();

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = 0,
                         curDebit = accountReceivableAdjustment.TotalAmount
                     },
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                         intIDMasCoaSub = journalEntry2.ID,
                         curCredit = accountReceivableAdjustment.TotalAmount,
                         curDebit = 0
                     }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }
                }

                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAdjustmentReceivableAdjusment;
            }
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCustomer(string criteria, int intIdAccountsReceivableAdjustmentsType)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithCustomer(criteria, intIdAccountsReceivableAdjustmentsType).ToList();

            }
        }

        public AccountReceivableAdjustment AddDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
              
                unitOfWork.AccountsReceivableAdjustments.Add(accountReceivableAdjustment);

                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = accountReceivableAdjustment.SalesId,
                    intIdCustomer = accountReceivableAdjustment.CustomerId,
                    //intIdCollection = accountReceivableAdjustment.Id,
                    intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    intIdSalesCustomerLedgerTransctionType = 3,
                    TotalAmount = accountReceivableAdjustment.TotalAmount,
                    TransactionDate = accountReceivableAdjustment.TransactionDate,
                    TransactionNo = accountReceivableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };

                if (UseDefaultEntry)
                {
             
                    var gLTranDetail = new List<tblGLTranDetail>();
                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 8,
                        strDescription = accountReceivableAdjustment.Descrpition,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = gLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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
                        intIDGLBookType = 8,
                        datBatchDate = accountReceivableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        //tblGLTranDetails = tblGLTranDetail,
                        intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
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

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);
                unitOfWork.Complete();
                return accountReceivableAdjustment;
            }
        }

        public AccountReceivableAdjustment UpdateDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                resultAdjustmentReceivableAdjusment.AccountsReceivableAdjustmentsTypeId = accountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                resultAdjustmentReceivableAdjusment.TransactionNo = accountReceivableAdjustment.TransactionNo;
                resultAdjustmentReceivableAdjusment.TransactionDate = accountReceivableAdjustment.TransactionDate;
                //resultAdjustmentReceivableAdjusment.CollectionId = accountReceivableAdjustment.CollectionId;
                resultAdjustmentReceivableAdjusment.Descrpition = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.SalesId = accountReceivableAdjustment.SalesId;
                resultAdjustmentReceivableAdjusment.CustomerId = accountReceivableAdjustment.CustomerId;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].strDescription = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].datBatchDate = accountReceivableAdjustment.TransactionDate;
                resultAdjustmentReceivableAdjusment.TotalAmount = accountReceivableAdjustment.TotalAmount;

                //var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);

                var salesCustomerLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                salesCustomerLedger.intIdCustomer = accountReceivableAdjustment.CustomerId;
                salesCustomerLedger.intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id;
                salesCustomerLedger.TotalAmount = accountReceivableAdjustment.TotalAmount;
                salesCustomerLedger.TransactionDate = accountReceivableAdjustment.TransactionDate;
                salesCustomerLedger.TransactionNo = accountReceivableAdjustment.TransactionNo;
                salesCustomerLedger.DateInserted = DateTime.Now;
   
                unitOfWork.GLTranDetail.RemoveRange(resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {
                    var gLTranDetailDefault = new List<tblGLTranDetail>();
                    foreach (var item in gLTranDetailDefault)
                    {
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub

                        });
                    }
                }

                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultAdjustmentReceivableAdjusment;
            }
        }

        public void RemoveDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                var tblGlTranDetails = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);

                unitOfWork.AccountsReceivableAdjustments.Remove(resultAdjustmentReceivableAdjusment);
                unitOfWork.Complete();
            }
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithSales(string criteria, int intIdAccountsReceivableAdjustmentsType)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithSales(criteria, intIdAccountsReceivableAdjustmentsType).ToList();

            }
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDMCM(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsDMCM(criteria).ToList();

            }
        }
    }
}
