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
                    intIdPurchase = accountPayableAdjustment.PurchaseId,
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

        private void AddAccountPayableAdjustmentDetails(AccountPayableAdjustment accountPayableAdjustment, List<AccountPayableAdjustmentsDetail> details, UnitOfWork unitOfWork)
        {
            // Example implementation. Adjust based on your entities and logic.
            foreach (var item in details)
            {
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(item.ProductId ?? 0);
                accountPayableAdjustment.AccountPayableAdjustmentsDetails.Add(new AccountPayableAdjustmentsDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    UnitPrice = item.UnitPrice,
                    Product = product

                });

                accountPayableAdjustment.Stocks.Add(new Stock
                {

                    ProductId = item.ProductId,
                    QuantityIn = 0,
                    QuantityOut = item.Quantity,
                    StockTransactionTypeID = 1002,
                    AccountsPayablePurchaseReturnID = accountPayableAdjustment.Id,
                    Product = product
                });
            }
        }


        private void AddPurchaseSupplierLedgerForReturn(UnitOfWork unitOfWork, AccountPayableAdjustment accountPayableAdjustment)
        {
            throw new NotImplementedException();
        }

        public void UpdateRemainingCount(UnitOfWork unitOfWork, AccountPayableAdjustment accountPayableAdjustment, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetail)
        {

            foreach (var detail in accountPayableAdjustmentsDetail)
            {
                int productID = (detail.ProductId.HasValue) ? detail.ProductId.Value : 0;

                var product = unitOfWork.Products.Get(productID);

                // Part 1: Your implementation start here...
                // You might want to get the stock list specific to the product
                //var stocks = unitOfWork.Stock.FindLocal(s => s.ProductId == detail.ProductId).ToList();

                var newStocks = accountPayableAdjustment.Stocks.ToList();

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

        public void AddGLTranInventory(UnitOfWork unitOfWork, AccountPayableAdjustment accountPayableAdjustment)
        {

            var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
            var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

            var gLTranDetail = new List<tblGLTranDetail>
            {
                CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, accountPayableAdjustment.TotalAmount.Value,0),
                CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, accountPayableAdjustment.TotalAmount.Value),
            };

            //AddGLTranHeader(unitOfWork, purchase, gLTranDetail);

            StringBuilder productDetailsBuilder = new StringBuilder();

            productDetailsBuilder.AppendLine(accountPayableAdjustment.Description);
            //productDetailsBuilder.AppendLine("( " + accountPayableAdjustment.AdditionalDescription + " )");

            var gLTranHeader = new tblGLTranHeader
            {
                curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                intIDGLBookType = 1011,
                strTransactionCode = accountPayableAdjustment.TransactionNo,
                strDescription = productDetailsBuilder.ToString(),
                datBatchDate = accountPayableAdjustment.TransactionDate,
                datInsertedDate = DateTime.Now,
                tblGLTranDetails = gLTranDetail,
                intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                blnUseDefaultEntry = true
            };
            unitOfWork.GLTran.Add(gLTranHeader);
        }

        public AccountPayableAdjustment AddReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                var purchaseDetails = unitOfWork.PurchaseDetail.Find(d => d.PurchaseId == purchase.Id);
                AddAccountPayableAdjustmentDetails(accountPayableAdjustment, accountPayableAdjustmentsDetail, unitOfWork);

                StringBuilder productDetailsBuilder = new StringBuilder();
                foreach (var detail in accountPayableAdjustmentsDetail)
                {
                    var existingPurchaseDetail = purchaseDetails.Where(pd => pd.ProductId == detail.ProductId).FirstOrDefault();

                    if (existingPurchaseDetail != null)
                    {
                        // Check if ReturnedQuantity is null and initialize it to 0 if it is
                        if (!existingPurchaseDetail.ReturnedQuantity.HasValue)
                        {
                            existingPurchaseDetail.ReturnedQuantity = 0;
                        }
                        existingPurchaseDetail.ReturnedQuantity += detail.Quantity;
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

                accountPayableAdjustment.Description = productDetailsBuilder.ToString();
                unitOfWork.AccountsPayableAdjustments.Add(accountPayableAdjustment);
                UpdateRemainingCount(unitOfWork, accountPayableAdjustment, accountPayableAdjustmentsDetail);

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
                             curCredit = accountPayableAdjustment.TotalAmount.Value,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2.ID,
                             curCredit = 0,
                             curDebit = accountPayableAdjustment.TotalAmount.Value
                         }
                    };

                    var gLTranHeader = new tblGLTranHeader
                    {
                        curCreditAmount = gLTranDetail.Sum(d => d.curCredit),
                        curDebitAmount = gLTranDetail.Sum(d => d.curDebit),
                        intIDGLBookType = 11,
                        strTransactionCode = accountPayableAdjustment.TransactionNo,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        strDescription = accountPayableAdjustment.Description,
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
                        strTransactionCode = accountPayableAdjustment.TransactionNo,
                        datBatchDate = accountPayableAdjustment.TransactionDate,
                        datInsertedDate = DateTime.Now,
                        strDescription = accountPayableAdjustment.Description,
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
                AddGLTranInventory(unitOfWork, accountPayableAdjustment);
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

        public void RemoveReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();


                // Delete existing purchase details and stock records
                foreach (var existingDetail in accountPayableAdjustmentsDetail.ToList())
                {
                    var accountsPayableAdjustmentDetailExist = unitOfWork.AccountsPayableAdjustmentsDetail.Get(existingDetail.Id);
                    unitOfWork.AccountsPayableAdjustmentsDetail.Remove(accountsPayableAdjustmentDetailExist);


                    //var existingStock = updatedPurchase.Stocks.FirstOrDefault(s => s.ProductId == existingDetail.ProductId);

                    var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.AccountsPayablePurchaseReturnID == existingDetail.AccountsPayableAdjustmentID).FirstOrDefault();
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

                    var purchaseDetails = unitOfWork.PurchaseDetail.Find(d => d.PurchaseId == accountPayableAdjustment.PurchaseId && d.ProductId == productID).FirstOrDefault();

                    var accountsPayableAdjustmentDetailToRecomputeList = unitOfWork.AccountsPayableAdjustmentsDetail.Find(a =>
                    a.AccountPayableAdjustment.PurchaseId == accountPayableAdjustment.PurchaseId &&
                    a.ProductId == productID).ToList();

                    accountsPayableAdjustmentDetailToRecomputeList = accountsPayableAdjustmentDetailToRecomputeList.Where(accountPayableAdj => unitOfWork.GetEntityState(accountPayableAdj) != EntityState.Deleted).ToList();
                    var totalReturnQuantity = (int)accountsPayableAdjustmentDetailToRecomputeList.Sum(a => a.Quantity);

                    purchaseDetails.ReturnedQuantity = totalReturnQuantity;

                }



                var tblGlTranDetails = resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList(); //Return Purchase Entry
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetails);

                var tblGlTranDetailsInventory = resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[1].tblGLTranDetails.ToList(); //Inventory
                unitOfWork.GLTranDetail.RemoveRange(tblGlTranDetailsInventory);

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
                resultAccountPayableAdjustment.PurchaseId = accountPayableAdjustment.PurchaseId;
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

        private void UpdateAccountPayableAdjustmentDetails(AccountPayableAdjustment accountPayableAdjustment, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentDetailsList, UnitOfWork unitOfWork)
        {

            // Delete existing purchase details and stock records
            foreach (var existingDetail in accountPayableAdjustment.AccountPayableAdjustmentsDetails.ToList())
            {
                var accountsPayableAdjustmentDetailExist = unitOfWork.AccountsPayableAdjustmentsDetail.Get(existingDetail.Id);
                unitOfWork.AccountsPayableAdjustmentsDetail.Remove(accountsPayableAdjustmentDetailExist);


                //var existingStock = updatedPurchase.Stocks.FirstOrDefault(s => s.ProductId == existingDetail.ProductId);

                var existingStock = unitOfWork.Stock.Find(s => s.ProductId == existingDetail.ProductId && s.AccountsPayablePurchaseReturnID == existingDetail.AccountsPayableAdjustmentID).FirstOrDefault();
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

                var purchaseDetails = unitOfWork.PurchaseDetail.Find(d => d.PurchaseId == accountPayableAdjustment.PurchaseId && d.ProductId == productID).FirstOrDefault();

                var accountsPayableAdjustmentDetailToRecomputeList = unitOfWork.AccountsPayableAdjustmentsDetail.Find(a =>
                a.AccountPayableAdjustment.PurchaseId == accountPayableAdjustment.PurchaseId &&
                a.ProductId == productID).ToList();

                accountsPayableAdjustmentDetailToRecomputeList = accountsPayableAdjustmentDetailToRecomputeList.Where(accountPayableAdj => unitOfWork.GetEntityState(accountPayableAdj) != EntityState.Deleted).ToList();
                var totalReturnQuantity = (int)accountsPayableAdjustmentDetailToRecomputeList.Sum(a => a.Quantity);

                purchaseDetails.ReturnedQuantity = totalReturnQuantity;


            }
            accountPayableAdjustment.AccountPayableAdjustmentsDetails.Clear();
            accountPayableAdjustment.Stocks.Clear();

            // Add new purchase details and stock records
            foreach (var updatedDetail in accountPayableAdjustmentDetailsList)
            {

                int productID = (updatedDetail.ProductId.HasValue) ? updatedDetail.ProductId.Value : 0;
                var product = unitOfWork.Products.GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(productID);

                var accountPayableAdjustmentsDetailNew = new AccountPayableAdjustmentsDetail
                {
                    //PurchaseId = updatedDetail.Id,
                    ProductId = updatedDetail.ProductId,
                    Quantity = updatedDetail.Quantity,
                    TotalPrice = updatedDetail.TotalPrice,
                    UnitPrice = updatedDetail.UnitPrice,
                    Product = product
                };

                accountPayableAdjustment.AccountPayableAdjustmentsDetails.Add(accountPayableAdjustmentsDetailNew);

                var purchaseDetails = unitOfWork.PurchaseDetail.Find(d => d.PurchaseId == accountPayableAdjustment.PurchaseId && d.ProductId == productID).FirstOrDefault();
                purchaseDetails.ReturnedQuantity += accountPayableAdjustmentsDetailNew.Quantity;

                accountPayableAdjustment.Stocks.Add(new Stock
                {
                    ProductId = updatedDetail.ProductId,
                    QuantityIn = 0,
                    QuantityOut = updatedDetail.Quantity,
                    StockTransactionTypeID = 1002,
                    AccountsPayablePurchaseReturnID = accountPayableAdjustment.Id
                });
            }
        }

        public AccountPayableAdjustment UpdateReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetail)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
        
                UpdateAccountPayableAdjustmentDetails(accountPayableAdjustment, accountPayableAdjustmentsDetail, unitOfWork);
                var resultAccountPayableAdjustment = unitOfWork.AccountsPayableAdjustments.GetAccountPayableAdjustmentsWithJournalEntry(accountPayableAdjustment.Id).SingleOrDefault();

                resultAccountPayableAdjustment.AccountsPayableAdjustmentTypeId = accountPayableAdjustment.AccountsPayableAdjustmentTypeId;
                resultAccountPayableAdjustment.TransactionNo = accountPayableAdjustment.TransactionNo;
                resultAccountPayableAdjustment.TransactionDate = accountPayableAdjustment.TransactionDate;
                //resultAccountPayableAdjustment.PaymentId = accountPayableAdjustment.PaymentId;
                //resultAccountPayableAdjustment.Description = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.PurchaseId = accountPayableAdjustment.PurchaseId;
                resultAccountPayableAdjustment.TotalAmount = accountPayableAdjustment.TotalAmount;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].strDescription = accountPayableAdjustment.Description;
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].datBatchDate = accountPayableAdjustment.TransactionDate;

                var purchase = unitOfWork.Purchase.Get((int)accountPayableAdjustment.PurchaseId);
                var purchaseDetails = unitOfWork.PurchaseDetail.Find(d => d.PurchaseId == purchase.Id);
                StringBuilder productDetailsBuilder = new StringBuilder();

                foreach (var detail in accountPayableAdjustmentsDetail)
                {
                    var existingPurchaseDetail = purchaseDetails.Where(pd => pd.ProductId == detail.ProductId).FirstOrDefault();




                    var product = detail.Product; // Assuming you can navigate to Product from SalesDetail
                    var size = product.ProductSize; // Assuming Product has a Size property
                    var color = product.ProductColor; // Assuming Product has a Color property

                    productDetailsBuilder.AppendLine("# " + product.strProductName +
                                                     "; Size: " + size.strName +
                                                     "; Color: " + color.strName +
                                                     "; Qty: " + detail.Quantity.ToString());

                }

                resultAccountPayableAdjustment.Description = productDetailsBuilder.ToString();
                resultAccountPayableAdjustment.AccountPayableAdjustmentsDetails = accountPayableAdjustment.AccountPayableAdjustmentsDetails;

                //foreach (var item in accountPayableAdjustment.AccountPayableAdjustmentsDetails)
                //{
                //    resultAccountPayableAdjustment.AccountPayableAdjustmentsDetails.Add(new AccountPayableAdjustmentsDetail
                //    {
                //        ProductId = item.ProductId,
                //        Quantity = item.Quantity,
                //        TotalPrice = item.TotalPrice,
                //        UnitPrice = item.UnitPrice,
                //        Product = item.Product

                //    });
                //}

                resultAccountPayableAdjustment.Stocks = accountPayableAdjustment.Stocks;
                UpdateRemainingCount(unitOfWork, accountPayableAdjustment, accountPayableAdjustmentsDetail);
                //var payment = unitOfWork.Payment.Get((int)accountPayableAdjustment.PaymentId);


                //TODO:recheck PurchaseSupplierLedger and refer to purchase update method. Find method and Delete method 05112024
                var purchaseCustomerLedgerExisting = unitOfWork.PurchaseSupplierLedger.Find(p => p.intIdAccountPayableAdjustment == accountPayableAdjustment.Id && p.intIdPurchaseSupplierLedgerTransactionType == 3).SingleOrDefault();

                if (purchaseCustomerLedgerExisting != null)
                {
                    unitOfWork.PurchaseSupplierLedger.Remove(purchaseCustomerLedgerExisting);
                }

                var purchaseCustomerLedger = new PurchaseSupplierLedger
                {
                    intIdPurchase = resultAccountPayableAdjustment.PurchaseId,
                    intIdSupplier = purchase.intIDSupplier,
                    intIdPurchaseSupplierLedgerTransactionType = 3,
                    intIdAccountPayableAdjustment = accountPayableAdjustment.Id,
                    TotalAmount = resultAccountPayableAdjustment.TotalAmount,
                    TransactionDate = accountPayableAdjustment.TransactionDate,
                    TransactionNo = accountPayableAdjustment.TransactionNo,
                    DateInserted = DateTime.Now
                };


                unitOfWork.PurchaseSupplierLedger.Add(purchaseCustomerLedger);
                purchase.IsPurchaseReturn = true;

                unitOfWork.GLTranDetail.RemoveRange(resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].tblGLTranDetails.ToList());

                if (UseDefaultEntry)
                {
                    var journalEntry1Inv = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES
                    var journalEntry2Inv = unitOfWork.CoaSub.Find(c => c.ID == 1056).SingleOrDefault(); // SALES

                    var gLTranDetailDefault = new List<tblGLTranDetail>
                    {
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry1Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry1Inv.ID,
                             curCredit = accountPayableAdjustment.TotalAmount.Value,
                             curDebit = 0
                         },
                         new tblGLTranDetail
                         {
                             intIDMasCoa = (int)journalEntry2Inv.intIDMasCOA ,
                             intIDMasCoaSub = journalEntry2Inv.ID,
                             curCredit = 0,
                             curDebit = accountPayableAdjustment.TotalAmount.Value
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
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].strDescription =  productDetailsBuilder.ToString();
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curCreditAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curCredit);
                resultAccountPayableAdjustment.tblGLTranHeaders.ToList()[0].curDebitAmount = resultAccountPayableAdjustment.tblGLTranHeaders.SelectMany(h => h.tblGLTranDetails).Sum(d => d.curDebit);

                var existingGLTranHeaderInventory = unitOfWork.GLTran.Find(h => h.intIdAccountPayableAdjustment == resultAccountPayableAdjustment.Id && h.intIDGLBookType == 1011).SingleOrDefault();

                if (existingGLTranHeaderInventory != null) {
                    var existingGLTranDetailInventory = unitOfWork.GLTranDetail.Find(g => g.intIDGLTranHeader == existingGLTranHeaderInventory.ID);

                    if (existingGLTranDetailInventory != null)
                    {
                        unitOfWork.GLTranDetail.RemoveRange(existingGLTranDetailInventory);
                    }

                 
                }
                //TODO:update inventory entry
                existingGLTranHeaderInventory.datBatchDate = resultAccountPayableAdjustment.TransactionDate;
                StringBuilder productDetailsBuilderInventory = new StringBuilder();
                productDetailsBuilderInventory.AppendLine(resultAccountPayableAdjustment.Description);
                existingGLTranHeaderInventory.strDescription = productDetailsBuilderInventory.ToString();
                existingGLTranHeaderInventory.strTransactionCode = resultAccountPayableAdjustment.TransactionNo;
                existingGLTranHeaderInventory.blnUseDefaultEntry = true;
                //productDetailsBuilderInventory.AppendLine("(" + resultAccountPayableAdjustment);


                var journalEntry3 = unitOfWork.CoaSub.Find(c => c.ID == 1028).SingleOrDefault(); // INVENTORY
                var journalEntry1 = unitOfWork.CoaSub.Find(c => c.ID == 1071).SingleOrDefault(); // ACCOUNTS RECEIVABLE- SALES

                //var gLTranDetail = new List<tblGLTranDetail>
                // {
                //     CreateGLTranDetail((int)journalEntry3.intIDMasCOA, journalEntry3.ID, accountPayableAdjustment.TotalAmount.Value,0),
                //     CreateGLTranDetail((int)journalEntry1.intIDMasCOA, journalEntry1.ID, 0, accountPayableAdjustment.TotalAmount.Value),
                // };


                var gLTranDetail = new List<tblGLTranDetail>
                 {
                     new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry3.intIDMasCOA,
                         intIDMasCoaSub = journalEntry3.ID,
                         curCredit = accountPayableAdjustment.TotalAmount.Value,
                         curDebit = 0,
                         intIDGLTranHeader = existingGLTranHeaderInventory.ID
                     },
                       new tblGLTranDetail
                     {
                         intIDMasCoa = (int)journalEntry1.intIDMasCOA,
                         intIDMasCoaSub = journalEntry1.ID,
                         curCredit = 0,
                         curDebit = accountPayableAdjustment.TotalAmount.Value,
                         intIDGLTranHeader = existingGLTranHeaderInventory.ID
                     }

                 };

                unitOfWork.GLTranDetail.AddRange(gLTranDetail);

                existingGLTranHeaderInventory.curDebitAmount = gLTranDetail.Sum(c => c.curDebit);
                existingGLTranHeaderInventory.curCreditAmount = gLTranDetail.Sum(c => c.curCredit);

                //AddGLTranInventory(unitOfWork, accountPayableAdjustment);
                unitOfWork.Complete();
                return resultAccountPayableAdjustment;
            }
        }
    }
}
