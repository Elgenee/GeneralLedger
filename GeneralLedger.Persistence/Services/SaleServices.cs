using System;
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
    public class SaleServices : ISaleServices
    {
        //public Sale Add(Sale sale , List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry)
        //{
        //    using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
        //    {
        //       unitOfWork.Sale.Add(sale);

        //        var salesCustomerLedger = new SalesCustomerLedger { 
        //         intIdSales = sale.Id,
        //         intIdCustomer = sale.intIdCustomer,
        //         intIdSalesCustomerLedgerTransctionType = 1,
        //         TotalAmount = sale.Total,
        //         TransactionDate = sale.TransactionDate,
        //         TransactionNo = sale.TRANo,
        //         DateInserted = DateTime.Now
        //        };

        //        unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);

        //        if (UseDefaultEntry)
        //        {
        //            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
        //            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
        //            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
        //            var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
        //            var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

        //            var gLTranDetail = new List<tblGLTranDetail>
        //            {
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry1.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry1.ID,
        //                     curCredit = 0,
        //                     curDebit = sale.Total 
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry2.ID,
        //                     curCredit = sale.SOPAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry3.ID,
        //                     curCredit = sale.COMMAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry4.ID,
        //                     curCredit = sale.CFAmount,
        //                     curDebit = 0
        //                 },
        //                 new tblGLTranDetail
        //                 {
        //                     intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
        //                     intIDMasCoaSub = journalEntry5.ID,
        //                     curCredit = sale.Total - (sale.COMMAmount + sale.SOPAmount + sale.CFAmount),
        //                     curDebit = 0
        //                 }
        //            };

        //            var gLTranHeader = new tblGLTranHeader
        //            {
        //                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
        //                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
        //                intIDGLBookType = 6,
        //                //strTransactionCode = "SAL-" + sale.Id,
        //                strDescription = sale.Description,
        //                datBatchDate = sale.TransactionDate,
        //                datInsertedDate = DateTime.Now,
        //                tblGLTranDetails = gLTranDetail,
        //                intIdSales = sale.Id,
        //                blnUseDefaultEntry = UseDefaultEntry
        //            };

        //            unitOfWork.GLTran.Add(gLTranHeader);
        //        }
        //        else
        //        {
        //            var gLTranHeader = new tblGLTranHeader
        //            {
        //                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
        //                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
        //                intIDGLBookType = 6,
        //                //strTransactionCode = "SAL-" + sale.Id,
        //                strDescription = sale.Description,
        //                datBatchDate = sale.TransactionDate,
        //                datInsertedDate = DateTime.Now,
        //                //tblGLTranDetails = tblGLTranDetail,
        //                intIdSales = sale.Id,
        //                blnUseDefaultEntry = UseDefaultEntry
        //            };

        //            foreach (var item in tblGLTranDetail)
        //            {
        //                gLTranHeader.tblGLTranDetails.Add(new tblGLTranDetail
        //                {
        //                    intIDMasCoa = item.intIDMasCoa,
        //                    intIDMasCoaSub = item.intIDMasCoaSub,
        //                    curCredit = item.curCredit,
        //                    curDebit = item.curDebit

        //                });
        //            }
        //            unitOfWork.GLTran.Add(gLTranHeader);
        //        }


        //        //var result = unitOfWork.GLTran.GetGLEntryById(9030);
        //        unitOfWork.Complete();
        //        return sale;
        //    }
        //}

        public Sale Add(Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool useDefaultEntry, List<SalesDetail> saleDetailsList)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                AddSaleDetails(sale, saleDetailsList,unitOfWork);
                unitOfWork.Sale.Add(sale);
                UpdateSaleCount(unitOfWork, sale, saleDetailsList);
                AddSalesCustomerLedger(unitOfWork, sale);
                AddGLTranForSale(unitOfWork, sale, tblGLTranDetail, useDefaultEntry);
                AddGLTranInventoryForSale(unitOfWork, sale);
                unitOfWork.Complete();
                return sale;
            }
        }

        private void AddSaleDetails(Sale sale, List<SalesDetail> saleDetailsList, UnitOfWork unitOfWork)
        {
            foreach (var item in saleDetailsList)
            {
                sale.SalesDetails.Add(new SalesDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice
                });

                sale.Stocks.Add(new Stock
                {
                    ProductId = item.ProductId,
                    QuantityIn = 0,
                    QuantityOut = item.Quantity,
                    StockTransactionTypeID = 2, 
                    SalesID = sale.Id
                });
            }
        }

        private void UpdateSaleCount(UnitOfWork unitOfWork, Sale sale, List<SalesDetail> saleDetailsList)
        {
            foreach (var detail in saleDetailsList)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;

                if (productID == 0)
                    continue; // Skip the iteration if ProductId is not set

                var product = unitOfWork.Products.Get(productID);

                if (product == null)
                    continue; // Skip the iteration if no product is found for the given ID

                var newStocksOut = sale.Stocks.ToList();
                product.intRemainingCount = GetTotalRemainingStock(unitOfWork, productID, newStocksOut);

            }
        }


        public int GetTotalRemainingStock(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId)); // Include new stocks
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
        }

        private void AddSalesCustomerLedger(UnitOfWork unitOfWork, Sale sale)
        {
            var saleCustomerLedger = new SalesCustomerLedger
            {
                intIdSales = sale.Id,
                intIdCustomer = sale.intIdCustomer,
                intIdSalesCustomerLedgerTransctionType = 1,
                TotalAmount = sale.Total,
                TransactionDate = sale.TransactionDate,
                TransactionNo = sale.TRANo,
                DateInserted = DateTime.Now
            };

            unitOfWork.SalesCustomerLedger.Add(saleCustomerLedger);
        }

        private void AddGLTranForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool useDefaultEntry)
        {
            if (useDefaultEntry)
            {
                AddDefaultGLTranForSale(unitOfWork, sale);
            }
            else
            {
                AddCustomGLTranForSale(unitOfWork, sale, tblGLTranDetail);
            }
        }


        private void AddDefaultGLTranForSale(UnitOfWork unitOfWork, Sale sale)
        {
            // Assuming IDs for SALES related account codes
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
            var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
            var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
            var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, sale.Total.Value),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, sale.SOPAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, sale.COMMAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, sale.CFAmount.Value, 0),
                CreateGLTranDetail((int)journalEntry2.intIDMasCOA, journalEntry2.ID, sale.Total.Value - (sale.COMMAmount.Value + sale.SOPAmount.Value + sale.CFAmount.Value), 0),
            };

            AddGLTranHeaderForSale(unitOfWork, sale, gLTranDetail);
        }

        private void AddCustomGLTranForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> tblGLTranDetail)
        {
            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = tblGLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = tblGLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 6, // Update this ID based on your system configuration for sales
                strDescription = sale.Description,
                datBatchDate = sale.TransactionDate,
                datInsertedDate = DateTime.Now,
                intIdSales = sale.Id,
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


        private void AddGLTranHeaderForSale(UnitOfWork unitOfWork, Sale sale, List<tblGLTranDetail> gLTranDetail)
        {
            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 6, // Update if necessary
                strDescription = sale.Description,
                datBatchDate = sale.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdSales = sale.Id,
                blnUseDefaultEntry = true
            };

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

        private void AddGLTranInventoryForSale(UnitOfWork unitOfWork, Sale sale)
        {
            // Logic for adding inventory transactions based on the sale.

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1072).SingleOrDefault(); // COST OF GOODS SOLD
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, 0, sale.Total.Value),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, sale.Total.Value, 0),
            };

            //AddGLTranHeader(unitOfWork, purchase, gLTranDetail);

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strDescription = sale.Description,
                datBatchDate = sale.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdSales = sale.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
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

        public List<Sale> GetSalesWithoutReturnSales(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetSalesWithoutReturnSales(criteria).ToList();

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

        public Sale Update(Sale sale, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<SalesDetail> salesDetails)
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
                salesLedger.intIdCustomer = sale.intIdCustomer;
                //resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList().Clear();
                unitOfWork.GLTranDetail.RemoveRange(resultSale.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2 = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SOP
                    var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // COMM
                    var journalEntry4 = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // CFA
                    var journalEntry5 = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

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
                             curCredit = sale.SOPAmount,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry3.ID,
                             curCredit = sale.COMMAmount,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry4.ID,
                             curCredit = sale.CFAmount,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry5.ID,
                             curCredit = sale.Total - (sale.COMMAmount + sale.SOPAmount + sale.CFAmount),
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
