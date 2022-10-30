using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptISIncome
    {

        public string strMonth { get; set; }
        public int intIDCOA { get; set; }
        public string strCOANamex { get; set; }
        public int intIDCOASubx { get; set; }
        public string strCOASubNamex { get; set; }
        public decimal curAmount { get; set; }
        public string strCOACode { get; set; }
        public string strIncome { get; set; }
    }
}
