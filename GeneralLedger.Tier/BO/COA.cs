using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class COA
    {
        public int ID { get; set; }
        public int intIDMasCOAGroup { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strAcctSide { get; set; }
        public string strCOANameGroup { get; set; }
        public string strAcctType { get; set; }
        public int ISOrdering { get; set; }
    }
}
