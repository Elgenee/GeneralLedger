using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class StockDetailsByProductId
    {
        public int Id { get; set; }
        public string StockTransactionTypeName { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public string TransactionCode{ get; set; }
        public DateTime TransactionDate { get; set; } // New property for Transaction Date

    }
}
