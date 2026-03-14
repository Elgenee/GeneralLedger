using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptInventoryMonthlyOutstandingSummary
    {
        public int ProductId { get; set; }
        public string strProductName { get; set; }
        public decimal OpeningQty { get; set; }
        public decimal QtyInMonth { get; set; }
        public decimal QtyOutMonth { get; set; }
        public decimal ClosingQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}
