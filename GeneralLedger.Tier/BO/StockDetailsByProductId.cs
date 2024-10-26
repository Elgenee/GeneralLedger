using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class StockDetailsByProductId
    {
        public string StockTransactionTypeName { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public string TransactionCode{ get; set; }

    }
}
