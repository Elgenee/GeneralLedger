using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptGetSummaryOfAccountsReceivablesSales
    {
        public string customerName { get; set; }
        public string TransactionDate { get; set; }
        public string TRANo { get; set; }
        public string agentName { get; set; }
        public Decimal Total { get; set; }
        public string datAsOfDate { get; set; }

    }
}
