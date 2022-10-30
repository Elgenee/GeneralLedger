using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class GLTBDtl
    {

        public int ID { get; set; }
        public int intIDTBBatchHdr { get; set; }
        public int COA { get; set; }
        public string COADesc { get; set; }
        public int COASub { get; set; }
        public string COASubDesc { get; set; }
        public decimal curBegBal { get; set; }
        public decimal curDebit { get; set; }
        public decimal curCredit { get; set; }
        public decimal curEndBal { get; set; }
        public string COAstrCode { get; set; }
    }
}
