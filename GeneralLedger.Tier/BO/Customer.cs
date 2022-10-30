using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal StartingDebit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        public decimal CreditLimit { get; set; }
        public int Terms { get; set; }
        public int PriceTypeID { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public PriceType PriceType { get; set; }

    }
}
