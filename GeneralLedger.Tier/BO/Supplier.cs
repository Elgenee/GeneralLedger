using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal StartingDebit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public int intIDBank { get; set; }
        public Bank Bank { get; set; }
    }
}
