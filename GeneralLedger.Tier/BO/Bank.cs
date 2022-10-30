using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class Bank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public int CurrencyID { get; set; }
        public decimal StartingDebit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }

    }
}
