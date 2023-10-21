using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptPurchaseProoflist
    {
        public string strBookType { get; set; }
        public string strTransactionNumber { get; set; }
        public string datBatchDate { get; set; }
        public string strTransactionCode { get; set; }
        public string strSupplier { get; set; }

        public string COA { get; set; }
        public string COASub { get; set; }

        public string strDescription { get; set; }

        public string strProduct { get; set; }

        public Decimal curDebit { get; set; }
        public Decimal curCredit { get; set; }


    }
}
