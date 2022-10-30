using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptOtherAsset
    {

        public int intIDCOA { get; set; }
        public string strCOAName { get; set; }
        public int intIDCOASub { get; set; }
        public string strCOASubName { get; set; }
        public decimal curAmount { get; set; }
    }
}
