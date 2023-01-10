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
    public class SaleServices : ISaleServices
    {
        public Sale Add(Sale sale , List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
               unitOfWork.Sale.Add(sale);

                var salesCustomerLedger = new SalesCustomerLedger { 
                 intIdSales = sale.Id,
                 intIdSalesCustomerLedgerTransctionType = 1,
                 TotalAmount = sale.Total,
                 TransactionDate = sale.TransactionDate,
                 TransactionNo = sale.TRANo,
                 DateInserted = DateTime.Now
                };

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);

                if (UseDefaultEntry)
                {
                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

                     var gLTranDetail = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = 0,
                             curDebit = sale.Total
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = sale.Total,
                             curDebit = 0
                         }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 6,
                        //strTransactionCode = "SAL-" + sale.Id,
                        strDescription = sale.Description,
                        datBatchDate = sale.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = gLTranDetail,
                        intIdSales = sale.Id,
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
                        intIDGLBookType = 6,
                        //strTransactionCode = "SAL-" + sale.Id,
                        strDescription = sale.Description,
                        datBatchDate = sale.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        tblGLTranDetails = tblGLTranDetail,
                        intIdSales = sale.Id,
                        blnUseDefaultEntry = UseDefaultEntry
                    };
                    unitOfWork.GLTran.Add(gLTranHeader);
                }
                //var result = unitOfWork.GLTran.GetGLEntryById(9030);
                unitOfWork.Complete();
                return sale;
            }
        }

        public List<Sale> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetAll().ToList();
            }
        }

        public Sale GetSale(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.Get(Id);
            }
        }

        public List<Sale> GetSaleWithCustomerAgent(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithCustomerAgent(criteria).ToList();

            }
        }

        public Sale GetSaleWithCustomerAgent(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithCustomerAgent(Id);

            }
        }

        public List<Sale> GetSaleWithJournalEntry(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSaleWithJournalEntry(Id).ToList();
    
            }
        }

        public void Remove(Sale sale)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultSale = unitOfWork.Sale.GetSaleWithJournalEntry(sale.Id).SingleOrDefault();
                var tblGlTranDetails = resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);
                var tblGLTranHeaders = resultSale.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);
                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdSales == sale.Id && s.intIdSalesCustomerLedgerTransctionType == 1).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);
                unitOfWork.Sale.Remove(resultSale);
                unitOfWork.Complete();
            }
        }

        public Sale Update(Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                //Update ledger if sale is updated
                var resultSale = unitOfWork.Sale.GetSaleWithJournalEntry(sale.Id).SingleOrDefault();
                resultSale.PONo = sale.PONo;
                resultSale.TRANo = sale.TRANo;
                resultSale.Total = sale.Total;
                resultSale.TransactionDate = sale.TransactionDate;
                resultSale.intIdCustomer = sale.intIdCustomer;
                resultSale.intIdAgent = sale.intIdAgent;
                resultSale.Terms = sale.Terms;
                resultSale.Description = sale.Description;
                resultSale.tblGLTranHeaders.ToList()[0].strDescription = sale.Description;
                resultSale.tblGLTranHeaders.ToList()[0].datBatchDate = sale.TransactionDate;

                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdSales == sale.Id && s.intIdSalesCustomerLedgerTransctionType == 1).SingleOrDefault();
                salesLedger.TotalAmount = sale.Total;
                salesLedger.TransactionDate = sale.TransactionDate;
                salesLedger.TransactionNo = sale.TRANo;
                //resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList().Clear();
                unitOfWork.GLTranDetail.RemoveRange(resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1.ID,
                             curCredit = 0,
                             curDebit = sale.Total
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = sale.Total,
                             curDebit = 0
                         }
                    };

                    foreach (var item in gLTranDetailDefault)
                    {
                        resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
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
                        resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.Add(new tblGLTranDetail
                        {
                            curCredit = item.curCredit,
                            curDebit = item.curDebit,
                            intIDGLTranHeader = item.intIDGLTranHeader,
                            intIDMasCoa = item.intIDMasCoa,
                            intIDMasCoaSub = item.intIDMasCoaSub
                       });
                    }
                }

                resultSale.tblGLTranHeaders.ToList()[0].blnUseDefaultEntry = UseDefaultEntry;
                resultSale.tblGLTranHeaders.ToList()[0].strDescription = resultSale.Description;
                resultSale.tblGLTranHeaders.ToList()[0].curCreditAmount = resultSale.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultSale.tblGLTranHeaders.ToList()[0].curDebitAmount = resultSale.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);
                unitOfWork.Complete();
                return resultSale;
            }
        }

    }
}
