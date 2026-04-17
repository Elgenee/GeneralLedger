using System;
using System.IO;
using System.Text;

namespace GeneralLedger.Persistence.Logging
{
    public static class SimpleLogger
    {
        private static readonly object lockObj = new object();
        private static string logDirectory;

        static SimpleLogger()
        {
            // Set log directory to application base directory
            logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            
            // Create logs directory if it doesn't exist
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        private static string GetLogFileName(string logType = "general")
        {
            string dateFolder = DateTime.Now.ToString("yyyy-MM");
            string dateFolderPath = Path.Combine(logDirectory, dateFolder);
            
            if (!Directory.Exists(dateFolderPath))
            {
                Directory.CreateDirectory(dateFolderPath);
            }

            string fileName = $"{logType}-{DateTime.Now:yyyy-MM-dd}.log";
            return Path.Combine(dateFolderPath, fileName);
        }

        private static void WriteLog(string logType, string level, string message, Exception ex = null)
        {
            try
            {
                lock (lockObj)
                {
                    string logFile = GetLogFileName(logType);
                    StringBuilder logMessage = new StringBuilder();
                    
                    logMessage.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] {message}");
                    
                    if (ex != null)
                    {
                        logMessage.AppendLine($"Exception: {ex.Message}");
                        logMessage.AppendLine($"StackTrace: {ex.StackTrace}");
                        
                        if (ex.InnerException != null)
                        {
                            logMessage.AppendLine($"InnerException: {ex.InnerException.Message}");
                        }
                    }
                    
                    logMessage.AppendLine(new string('-', 100));

                    File.AppendAllText(logFile, logMessage.ToString());
                }
            }
            catch
            {
                // Fail silently - don't let logging break the application
            }
        }

        #region General Logging

        public static void Info(string message)
        {
            WriteLog("general", "INFO", message);
        }

        public static void Warning(string message)
        {
            WriteLog("general", "WARNING", message);
        }

        public static void Error(string message, Exception ex = null)
        {
            WriteLog("errors", "ERROR", message, ex);
            WriteLog("general", "ERROR", message, ex);
        }

        public static void Debug(string message)
        {
            WriteLog("general", "DEBUG", message);
        }

        #endregion


        #region Stock Operations Logging

        /// <summary>
        /// Logs a stock query operation
        /// </summary>
        /// <param name="productId">Product ID being queried</param>
        /// <param name="salesId">Sales ID (null for non-sales operations)</param>
        /// <param name="purchaseId">Purchase ID (null for non-purchase operations)</param>
        /// <param name="inventoryAdjustmentId">Inventory Adjustment ID (null for non-adjustment operations)</param>
        /// <param name="stockTransactionTypeId">Stock transaction type (1=Purchase, 2=Sales, 3=Adjustment, etc.)</param>
        public static void LogStockQuery(int productId, int? salesId, int? purchaseId, int? inventoryAdjustmentId, int? stockTransactionTypeId)
        {
            string message = $"STOCK_QUERY | ProductId: {productId} | SalesId: {salesId?.ToString() ?? "NULL"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | InventoryAdjustmentId: {inventoryAdjustmentId?.ToString() ?? "NULL"} | TransactionType: {stockTransactionTypeId?.ToString() ?? "NULL"}";
            WriteLog("stock-operations", "INFO", message);
        }

        /// <summary>
        /// Logs when a stock record is found
        /// </summary>
        public static void LogStockFound(int stockId, int productId, int? salesId, int? purchaseId, int? inventoryAdjustmentId, int stockTransactionTypeId, decimal quantityIn, decimal quantityOut)
        {
            string message = $"STOCK_FOUND | StockId: {stockId} | ProductId: {productId} | SalesId: {salesId?.ToString() ?? "NULL"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | InventoryAdjustmentId: {inventoryAdjustmentId?.ToString() ?? "NULL"} | TransactionType: {stockTransactionTypeId} | QtyIn: {quantityIn} | QtyOut: {quantityOut}";
            WriteLog("stock-operations", "INFO", message);
        }

        /// <summary>
        /// Logs when a stock record is not found (warning)
        /// </summary>
        public static void LogStockNotFound(int productId, int? salesId, int? purchaseId, int? inventoryAdjustmentId)
        {
            string message = $"STOCK_NOT_FOUND | ProductId: {productId} | SalesId: {salesId?.ToString() ?? "NULL"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | InventoryAdjustmentId: {inventoryAdjustmentId?.ToString() ?? "NULL"}";
            WriteLog("stock-operations", "WARNING", message);
        }

        /// <summary>
        /// Logs stock deletion with full context
        /// </summary>
        public static void LogStockDeletion(int stockId, int productId, int? salesId, int? purchaseId, int? inventoryAdjustmentId, int stockTransactionTypeId, decimal quantityIn, decimal quantityOut, string reason)
        {
            string message = $"STOCK_DELETE | StockId: {stockId} | ProductId: {productId} | SalesId: {salesId?.ToString() ?? "NULL"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | InventoryAdjustmentId: {inventoryAdjustmentId?.ToString() ?? "NULL"} | TransactionType: {stockTransactionTypeId} | QtyIn: {quantityIn} | QtyOut: {quantityOut} | Reason: {reason}";
            WriteLog("stock-operations", "WARNING", message);
        }

        /// <summary>
        /// Logs stock creation
        /// </summary>
        public static void LogStockCreation(int productId, int? salesId, int? purchaseId, int? inventoryAdjustmentId, int stockTransactionTypeId, decimal quantityIn, decimal quantityOut)
        {
            string message = $"STOCK_CREATE | ProductId: {productId} | SalesId: {salesId?.ToString() ?? "NULL"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | InventoryAdjustmentId: {inventoryAdjustmentId?.ToString() ?? "NULL"} | TransactionType: {stockTransactionTypeId} | QtyIn: {quantityIn} | QtyOut: {quantityOut}";
            WriteLog("stock-operations", "INFO", message);
        }

        /// <summary>
        /// Logs stock validation results
        /// </summary>
        public static void LogStockValidation(int productId, string productName, int remainingCount, int requestedQuantity, bool isValid)
        {
            string status = isValid ? "VALID" : "INVALID";
            string message = $"STOCK_VALIDATION_{status} | ProductId: {productId} | Product: {productName} | Remaining: {remainingCount} | Requested: {requestedQuantity}";
            WriteLog("stock-operations", isValid ? "INFO" : "WARNING", message);
        }

        #endregion

        #region Sales Operations Logging

        public static void LogSaleOperation(string operation, int saleId, int? customerId, int? agentId, decimal? total)
        {
            string message = $"SALE_{operation.ToUpper()} | SaleId: {saleId} | CustomerId: {customerId?.ToString() ?? "NULL"} | AgentId: {agentId?.ToString() ?? "NULL"} | Total: {total?.ToString("F2") ?? "NULL"}";
            WriteLog("sales-operations", "INFO", message);
        }

        public static void LogSaleDetailOperation(string operation, int? saleDetailId, int? saleId, int? productId, decimal? quantity, decimal? unitPrice, decimal? totalPrice)
        {
            string message = $"SALEDETAIL_{operation.ToUpper()} | SaleDetailId: {saleDetailId?.ToString() ?? "NEW"} | SaleId: {saleId?.ToString() ?? "NULL"} | ProductId: {productId?.ToString() ?? "NULL"} | Qty: {quantity?.ToString() ?? "NULL"} | UnitPrice: {unitPrice?.ToString("F2") ?? "NULL"} | Total: {totalPrice?.ToString("F2") ?? "NULL"}";
            WriteLog("sales-operations", "INFO", message);
        }

        public static void LogSaleUpdate(int saleId, string propertyName, string oldValue, string newValue)
        {
            string message = $"SALE_UPDATE | SaleId: {saleId} | Property: {propertyName} | OldValue: {oldValue ?? "NULL"} | NewValue: {newValue ?? "NULL"}";
            WriteLog("sales-operations", "INFO", message);
        }

        #endregion

        #region Purchase Operations Logging

        public static void LogPurchaseOperation(string operation, int purchaseId, int? supplierId, decimal? total)
        {
            string message = $"PURCHASE_{operation.ToUpper()} | PurchaseId: {purchaseId} | SupplierId: {supplierId?.ToString() ?? "NULL"} | Total: {total?.ToString("F2") ?? "NULL"}";
            WriteLog("purchase-operations", "INFO", message);
        }

        public static void LogPurchaseDetailOperation(string operation, int? purchaseDetailId, int? purchaseId, int? productId, decimal? quantity, decimal? unitPrice, decimal? totalPrice)
        {
            string message = $"PURCHASEDETAIL_{operation.ToUpper()} | PurchaseDetailId: {purchaseDetailId?.ToString() ?? "NEW"} | PurchaseId: {purchaseId?.ToString() ?? "NULL"} | ProductId: {productId?.ToString() ?? "NULL"} | Qty: {quantity?.ToString() ?? "NULL"} | UnitPrice: {unitPrice?.ToString("F2") ?? "NULL"} | Total: {totalPrice?.ToString("F2") ?? "NULL"}";
            WriteLog("purchase-operations", "INFO", message);
        }

        public static void LogPurchaseUpdate(int purchaseId, string propertyName, string oldValue, string newValue)
        {
            string message = $"PURCHASE_UPDATE | PurchaseId: {purchaseId} | Property: {propertyName} | OldValue: {oldValue ?? "NULL"} | NewValue: {newValue ?? "NULL"}";
            WriteLog("purchase-operations", "INFO", message);
        }

        #endregion

        #region Critical Errors

        public static void LogCriticalError(string operation, string details, Exception ex)
        {
            string message = $"CRITICAL_ERROR | Operation: {operation} | Details: {details}";
            WriteLog("critical-errors", "CRITICAL", message, ex);
            WriteLog("errors", "CRITICAL", message, ex);
        }

        #endregion
    }
}