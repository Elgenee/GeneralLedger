using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class JournalEntry
    {
        public int ID { get; set; }
        public string strTransactionNumber { get; set; }
        public string datBatchDate { get; set; }
        public string strDescription { get; set; }
        public string strTransactionCode { get; set; }
        public GLTranHeader GLTranHeader { get; set; }

    }
}
