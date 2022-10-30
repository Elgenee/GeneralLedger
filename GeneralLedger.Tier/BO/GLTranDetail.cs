using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class GLTranDetail
    {
        public int ID { get; set; }
        public int intIDGLTranHeader { get; set; }
        public int intIDCOA { get; set; }
        public int intIDCOASub { get; set; }
        public Double curDebit { get; set; }
        public Double curCredit { get; set; }
        public COA COA { get; set; }
        public COASub COASub { get; set; }



    }
}
