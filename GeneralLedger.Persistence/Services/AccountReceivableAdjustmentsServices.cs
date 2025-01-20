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

        private void AddAccountReceivableAdjustmentDetails(AccountReceivableAdjustment accountReceivableAdjustment, List<AccountReceivableAdjustmentsDetail> details, UnitOfWork unitOfWork)
        {
            // Example implementation. Adjust based on your entities and logic.
            foreach (var item in details)
            {
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(item.ProductId ?? 0);
                accountReceivableAdjustment.AccountReceivableAdjustmentsDetails.Add(new AccountReceivableAdjustmentsDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                    Product = product

                });

                accountReceivableAdjustment.Stocks.Add(new Stock
                {

                    ProductId = item.ProductId,
                    QuantityIn = item.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 2002,
                    AccountsReceivableSaleReturnID = accountReceivableAdjustment.Id,
                    Product = product
                });
            }
        }

        public void UpdateRemainingCount(UnitOfWork unitOfWork, AccountReceivableAdjustment accountReceivableAdjustment, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetail)
        {

            foreach (var detail in accountReceivableAdjustmentsDetail)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;

                var product = unitOfWork.Products.Get(productID);

                // Part 1: Your implementation start here...
                // You might want to get the stock list specific to the product
                //var stocks = unitOfWork.Stock.FindLocal(s => s.ProductId == detail.ProductId).ToList();

                var newStocks = accountReceivableAdjustment.Stocks.ToList();

                product.intRemainingCount = GetTotalRemainingStock(unitOfWork, productID, newStocks);


            }
        }

        public int GetTotalRemainingStock(UnitOfWork unitOfWork, int productId, List<Stock> newStocks)
        {
            var stocks = unitOfWork.Stock.Find(x => x.ProductId == productId).ToList();
            stocks = stocks.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
            var totalStocks = stocks.Concat(newStocks.Where(x => x.ProductId == productId)); // Include new stocks
            return (int)totalStocks.Sum(stock => stock.QuantityIn - stock.QuantityOut);
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

        public void AddGLTranInventory(UnitOfWork unitOfWork, AccountReceivableAdjustment accountReceivableAdjustment)
        {

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1072).SingleOrDefault(); // COST OF GOODS SOLD

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, accountReceivableAdjustment.TotalInventoryAmount.Value,0),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, accountReceivableAdjustment.TotalInventoryAmount.Value),
            };

            //AddGLTranHeader(unitOfWork, purchase, gLTranDetail);

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(accountReceivableAdjustment.Descrpition);
            //productDetailsBuilder.AppendLine("( " + accountPayableAdjustment.AdditionalDescription + " )");

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strTransactionCode = accountReceivableAdjustment.TransactionNo,
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = accountReceivableAdjustment.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        public AccountReceivableAdjustment AddReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);
                var salesDetails = unitOfWork.SaleDetail.Find(s => s.SalesId == accountReceivableAdjustment.SalesId);
                AddAccountReceivableAdjustmentDetails(accountReceivableAdjustment, accountReceivableAdjustmentsDetail, unitOfWork);

                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in accountReceivableAdjustmentsDetail)
                {
                    var existingSalesDetail = salesDetails.Where(pd => pd.ProductId == detail.ProductId).FirstOrDefault();

                    if (existingSalesDetail != null)
                    {
                        // Check if ReturnedQuantity is null and initialize it to 0 if it is
                        if (!existingSalesDetail.ReturnedQuantity.HasValue)
                        {
                            existingSalesDetail.ReturnedQuantity = 0;
                        }
                        existingSalesDetail.ReturnedQuantity += detail.Quantity;
                    }

                    //implement here
                    var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                    var size = product.ProductSize; // Assuming Product has a Size property
                    var color = product.ProductColor; // Assuming Product has a Color property

                    productDetailsBuilder.AppendLine("# " + product.strProductName +
                                                     "; Size: " + size.strName +
                                                     "; Color: " + color.strName +
                                                     "; Qty: " + detail.Quantity.ToString());
                }

                accountReceivableAdjustment.Descrpition = productDetailsBuilder.ToString();
                unitOfWork.AccountsReceivableAdjustments.Add(accountReceivableAdjustment);
                UpdateRemainingCount(unitOfWork, accountReceivableAdjustment, accountReceivableAdjustmentsDetail);

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
                             curCredit = accountReceivableAdjustment.TotalAmount.Value,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.Sale.SOPAmount.Value,
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry3.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry3.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.Sale.COMMAmount.Value,
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry4.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry4.ID,
                             curCredit = 0,
                             curDebit =  accountReceivableAdjustment.Sale.CFAmount.Value,
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry5.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry5.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.TotalAmount.Value - (accountReceivableAdjustment.Sale.COMMAmount.Value + accountReceivableAdjustment.Sale.SOPAmount.Value + accountReceivableAdjustment.Sale.CFAmount.Value)
                         }
                    };


                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 8,
                        strDescription = accountReceivableAdjustment.Descrpition,
                        strTransactionCode = accountReceivableAdjustment.TransactionNo,
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
                        strDescription = accountReceivableAdjustment.Descrpition,
                        strTransactionCode = accountReceivableAdjustment.TransactionNo,
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
                AddGLTranInventory(unitOfWork, accountReceivableAdjustment);
                unitOfWork.Complete();
                return accountReceivableAdjustment;
            }
        }


        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id)
        {
            throw new NotImplementedException();
        }

        private void UpdateAccountReceivableAdjustmentDetails(AccountReceivableAdjustment accountReceivableAdjustment, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentDetailsList, UnitOfWork unitOfWork)
        {

            // Delete existing purchase details and stock records
            foreach (var existingDetail in accountReceivableAdjustment.AccountReceivableAdjustmentsDetails.ToList())
            {
                var accountsReceivableAdjustmentDetailExist = unitOfWork.AccountsReceivableAdjustmentsDetail.Get(existingDetail.Id);
                unitOfWork.AccountsReceivableAdjustmentsDetail.Remove(accountsReceivableAdjustmentDetailExist);


                //var existingStock = updatedPurchase.Stocks.FirstOrDefault(s => s.ProductId == existingDetail.ProductId);

                var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.AccountsReceivableSaleReturnID == existingDetail.AccountsReceivableAdjustmentsID).FirstOrDefault();
                if (existingStock != null)
                {
                    unitOfWork.Stock.Remove(existingStock);
                }

                int productID = (existingDetail.ProductId.HasValue) ? existingDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.Get(productID);


                var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId).ToList();
                existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
                var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
                product.intRemainingCount = totalStocks;

                var salesDetails = unitOfWork.SaleDetail.Find(d => d.SalesId == accountReceivableAdjustment.SalesId && d.ProductId == productID).FirstOrDefault();

                var accountsReceivableAdjustmentDetailToRecomputeList = unitOfWork.AccountsReceivableAdjustmentsDetail.Find(a =>
                a.AccountReceivableAdjustment.SalesId == accountReceivableAdjustment.SalesId &&
                a.ProductId == productID).ToList();

                accountsReceivableAdjustmentDetailToRecomputeList = accountsReceivableAdjustmentDetailToRecomputeList.Where(accountReceivableAdj => unitOfWork.GetEntityState(accountReceivableAdj) != EntityState.Deleted).ToList();
                var totalReturnQuantity = (int)accountsReceivableAdjustmentDetailToRecomputeList.Sum(a => a.Quantity);

                salesDetails.ReturnedQuantity = totalReturnQuantity;


            }
            accountReceivableAdjustment.AccountReceivableAdjustmentsDetails.Clear();
            accountReceivableAdjustment.Stocks.Clear();

            // Add new purchase details and stock records
            foreach (var updatedDetail in accountReceivableAdjustmentDetailsList)
            {

                int productID = (updatedDetail.ProductId.HasValue) ? updatedDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(productID);

                var accountReceivableAdjustmentsDetailNew = new AccountReceivableAdjustmentsDetail
                {
                    //PurchaseId = updatedDetail.Id,
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice,
                    Product = product
                };

                accountReceivableAdjustment.AccountReceivableAdjustmentsDetails.Add(accountReceivableAdjustmentsDetailNew);

                var salesDetails = unitOfWork.SaleDetail.Find(d => d.SalesId == accountReceivableAdjustment.SalesId && d.ProductId == productID).FirstOrDefault();
                salesDetails.ReturnedQuantity += accountReceivableAdjustmentsDetailNew.Quantity;

                accountReceivableAdjustment.Stocks.Add(new Stock
                {
                    ProductId = updatedDetail.ProductId,
                    QuantityIn = updatedDetail.Quantity,
                    QuantityOut = 0,
                    StockTransactionTypeID = 2002,
                    AccountsReceivableSaleReturnID = accountReceivableAdjustment.Id
                });
            }
        }

        public AccountReceivableAdjustment UpdateReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {

                UpdateAccountReceivableAdjustmentDetails(accountReceivableAdjustment, accountReceivableAdjustmentsDetail, unitOfWork);
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();
                resultAdjustmentReceivableAdjusment.AccountsReceivableAdjustmentsTypeId = accountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId;
                resultAdjustmentReceivableAdjusment.TransactionNo = accountReceivableAdjustment.TransactionNo;
                resultAdjustmentReceivableAdjusment.TransactionDate = accountReceivableAdjustment.TransactionDate;
                //resultAdjustmentReceivableAdjusment.CollectionId = accountReceivableAdjustment.CollectionId;

                resultAdjustmentReceivableAdjusment.SalesId = accountReceivableAdjustment.SalesId;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].strDescription = accountReceivableAdjustment.Descrpition;
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].datBatchDate = accountReceivableAdjustment.TransactionDate;
                resultAdjustmentReceivableAdjusment.TotalAmount = accountReceivableAdjustment.TotalAmount;
                resultAdjustmentReceivableAdjusment.TotalInventoryAmount = accountReceivableAdjustment.TotalInventoryAmount;

                var sales = unitOfWork.Sale.Get((int)accountReceivableAdjustment.SalesId);
                var salesDetails = unitOfWork.SaleDetail.Find(d => d.SalesId == sales.Id);
                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in accountReceivableAdjustmentsDetail)
                {
                    var existingPurchaseDetail = salesDetails.Where(pd => pd.ProductId == detail.ProductId).FirstOrDefault();




                    var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                    var size = product.ProductSize; // Assuming Product has a Size property
                    var color = product.ProductColor; // Assuming Product has a Color property

                    productDetailsBuilder.AppendLine("# " + product.strProductName +
                                                     "; Size: " + size.strName +
                                                     "; Color: " + color.strName +
                                                     "; Qty: " + detail.Quantity.ToString());

                }

                resultAdjustmentReceivableAdjusment.Descrpition = productDetailsBuilder.ToString();
                resultAdjustmentReceivableAdjusment.AccountReceivableAdjustmentsDetails = accountReceivableAdjustment.AccountReceivableAdjustmentsDetails;
                resultAdjustmentReceivableAdjusment.Stocks = accountReceivableAdjustment.Stocks;
                UpdateRemainingCount(unitOfWork, accountReceivableAdjustment, accountReceivableAdjustmentsDetail);

                var salesCustomerLedgerExisting = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();

                if (salesCustomerLedgerExisting != null)
                {
                    unitOfWork.SalesCustomerLedger.Remove(salesCustomerLedgerExisting);
                }

                var salesCustomerLedger = new SalesCustomerLedger
                {
                    intIdSales = resultAdjustmentReceivableAdjusment.SalesId,
                    intIdCustomer = sales.intIdCustomer,
                    intIdSalesCustomerLedgerTransctionType = 3,
                    intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id,
                    TotalAmount = resultAdjustmentReceivableAdjusment.TotalAmount,
                    TransactionDate = accountReceivableAdjustment.TransactionDate,
                    TransactionNo = accountReceivableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now

                };

                unitOfWork.SalesCustomerLedger.Add(salesCustomerLedger);
                //salesCustomerLedgerExisting.intIdSales = accountReceivableAdjustment.SalesId;
                //salesCustomerLedgerExisting.intIdAccountReceivableAdjustment = accountReceivableAdjustment.Id;
                //salesCustomerLedgerExisting.TotalAmount = accountReceivableAdjustment.TotalAmount;
                //salesCustomerLedgerExisting.TransactionDate = accountReceivableAdjustment.TransactionDate;
                //salesCustomerLedgerExisting.TransactionNo = accountReceivableAdjustment.TransactionNo;
                //salesCustomerLedgerExisting.DateInserted = DateTime.Now;
                sales.IsSalesReturn = true;

                unitOfWork.GLTranDetail.RemoveRange(resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {

                    var journalEntry1Inv = unitOfWork.CoaSub.Find(c => c.ID == 1029).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2Inv = unitOfWork.CoaSub.Find(c => c.ID == 1055).SingleOrDefault(); // SALES
                    var journalEntry3Inv = unitOfWork.CoaSub.Find(c => c.ID == 1053).SingleOrDefault(); // SALES
                    var journalEntry4Inv = unitOfWork.CoaSub.Find(c => c.ID == 2119).SingleOrDefault(); // SALES
                    var journalEntry5Inv = unitOfWork.CoaSub.Find(c => c.ID == 1065).SingleOrDefault(); // SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1Inv.ID,
                             curCredit = accountReceivableAdjustment.TotalAmount,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2Inv.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.Sale.SOPAmount.Value
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry3Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry3Inv.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.Sale.COMMAmount.Value
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry4Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry4Inv.ID,
                             curCredit = 0,
                             curDebit =  accountReceivableAdjustment.Sale.CFAmount.Value
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry5Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry5Inv.ID,
                             curCredit = 0,
                             curDebit = accountReceivableAdjustment.TotalAmount - (accountReceivableAdjustment.Sale.COMMAmount.Value + accountReceivableAdjustment.Sale.SOPAmount.Value + accountReceivableAdjustment.Sale.CFAmount.Value)
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
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].strDescription = productDetailsBuilder.ToString();
                //object test = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.Where(t => t.intIDGLBookType == 8).SelectMany(h => h.tblGLTranDetails).ToList();
                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAdjustmentReceivableAdjusment
                    .tblGLTranHeaders
                    .Where(t => t.intIDGLBookType == 8)
                    .SelectMany(h => h.tblGLTranDetails)
                    .Sum(d => d.curCredit);

                resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAdjustmentReceivableAdjusment
                    .tblGLTranHeaders
                    .Where(t => t.intIDGLBookType == 8)
                    .SelectMany(h => h.tblGLTranDetails)
                    .Sum(d => d.curDebit);

                var existingGLTranHeaderInventory = unitOfWork.GLTran.Find(h => h.intIdAccountReceivableAdjustment == resultAdjustmentReceivableAdjusment.Id && h.intIDGLBookType == 1011).SingleOrDefault();


                if (existingGLTranHeaderInventory != null)
                {
                    var existingGLTranDetailInventory = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeaderInventory.ID);

                    if (existingGLTranDetailInventory != null)
                    {
                        unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetailInventory);
                    }
                }

                existingGLTranHeaderInventory.datBatchDate = resultAdjustmentReceivableAdjusment.TransactionDate;
                StringBuilder productDetailsBuilderInventory = new StringBuilder();
                productDetailsBuilderInventory.AppendLine(resultAdjustmentReceivableAdjusment.Descrpition);
                existingGLTranHeaderInventory.strDescription = productDetailsBuilderInventory.ToString();
                existingGLTranHeaderInventory.strTransactionCode = resultAdjustmentReceivableAdjusment.TransactionNo;
                existingGLTranHeaderInventory.blnUseDefaultEntry = true;


                var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
                var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1072).SingleOrDefault(); // COST OF GOODS SOLD


                var gLTranDetail = new List<tblGLTranDetail>
                 {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                         intIDMasCoaSub = journalEntry3.ID,
                         curCredit = accountReceivableAdjustment.TotalInventoryAmount.Value,
                         curDebit = 0,
                         intIDGLTranHeader = existingGLTranHeaderInventory.ID
                     },
                       new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = 0,
                         curDebit = accountReceivableAdjustment.TotalInventoryAmount.Value,
                         intIDGLTranHeader = existingGLTranHeaderInventory.ID
                     }

                 };

                unitOfWork.GLTranDetail.AddRange(gLTranDetail);

                existingGLTranHeaderInventory.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
                existingGLTranHeaderInventory.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);

                unitOfWork.Complete();
                return resultAdjustmentReceivableAdjusment;
            }
        }

        public List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria, int intIdAccountsReceivableAdjustmentsType)
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

        public void RemoveReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAdjustmentReceivableAdjusment = unitOfWork.AccountsReceivableAdjustments.GetAccountReceivableAdjustmentsWithJournalEntry(accountReceivableAdjustment.Id).SingleOrDefault();

                foreach (var existingDetail in accountReceivableAdjustmentsDetail.ToList())
                {
                    var accountsReceivableAdjustmentDetailExist = unitOfWork.AccountsReceivableAdjustmentsDetail.Get(existingDetail.Id);
                    unitOfWork.AccountsReceivableAdjustmentsDetail.Remove(accountsReceivableAdjustmentDetailExist);

                    var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.AccountsReceivableSaleReturnID == existingDetail.AccountsReceivableAdjustmentsID).FirstOrDefault();

                    if (existingStock != null)
                    {
                        unitOfWork.Stock.Remove(existingStock);
                    }


                    int productID = (existingDetail.ProductId.HasValue) ? existingDetail.ProductId.Value : 0;
                    var product = unitOfWork.Products.Get(productID);

                    var existingStockList = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId).ToList();
                    existingStockList = existingStockList.Where(stock => unitOfWork.GetEntityState(stock) != EntityState.Deleted).ToList();
                    var totalStocks = (int)existingStockList.Sum(stock => stock.QuantityIn - stock.QuantityOut);
                    product.intRemainingCount = totalStocks;

                    var salesDetails = unitOfWork.SaleDetail.Find(s => s.SalesId == accountReceivableAdjustment.SalesId && s.ProductId == productID).FirstOrDefault();

                    var accountsReceivableAdjustmentsDetailRecomputeList = unitOfWork.AccountsReceivableAdjustmentsDetail.Find(a =>
                    a.AccountReceivableAdjustment.SalesId == accountReceivableAdjustment.SalesId &&
                    a.ProductId == productID).ToList();

                    accountsReceivableAdjustmentsDetailRecomputeList = accountsReceivableAdjustmentsDetailRecomputeList.Where(accountReceivableAdj => unitOfWork.GetEntityState(accountReceivableAdj) != EntityState.Deleted).ToList();
                    var totalReturnQuantity = (int)accountsReceivableAdjustmentsDetailRecomputeList.Sum(a => a.Quantity);

                    salesDetails.ReturnedQuantity = totalReturnQuantity;

                }

                var tblGlTranDetails = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList();
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);

                var tblGlTranDetailsInventory = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList()[1].tblGLTranDetails.ToList(); //Inventory
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetailsInventory);

                var tblGLTranHeaders = resultAdjustmentReceivableAdjusment.tblGLTranHeaders.ToList();
                unitOfWork.GLTran.RemoveRange(tblGLTranHeaders);


                var salesLedger = unitOfWork.SalesCustomerLedger.Find(s => s.intIdAccountReceivableAdjustment == accountReceivableAdjustment.Id && s.intIdSalesCustomerLedgerTransctionType == 3).SingleOrDefault();
                unitOfWork.SalesCustomerLedger.Remove(salesLedger);

                var adjSumList = unitOfWork.SalesCustomerLedger
                    .Find(s => s.intIdSales == salesLedger.intIdSales &&
                    s.intIdSalesCustomerLedgerTransctionType == 3 && s.AccountReceivableAdjustment.AccountsReceivableAdjustmentsTypeId == 1002).ToList();

                adjSumList.Remove(salesLedger);

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

        //public AccountReceivableAdjustment AddReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetailList)
        //{
        //    throw new NotImplementedException();
        //}

        //public AccountReceivableAdjustment UpdateReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetailList)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<AccountReceivableAdjustmentsDetail> accountReceivableAdjustmentsDetailList)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
