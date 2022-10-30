using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class GLTranHeader
    {
        public int ID { get; set; }
        public int intIDGLBookType { get; set; }
        public string datBatchDate { get; set; }
        public int intIDReference { get; set; }
        public string strTransactionCode { get; set; }
        public double curCreditAmount { get; set; }
        public double curDebitAmount { get; set; }
        public string strDescription { get; set; }
        public List<GLTranDetail> listOfGLTranDetail { get; set; }

    }
}
