using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class PurchaseOrderReceiving
    {
        public int ID { get; set; }
        public string DateReceived { get; set; }
        public int PurchaseOrderID { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public string Address { get; set; }
        public string Memo { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalReceived { get; set; }
        public decimal TotalRemaining { get; set; }
        public List<PurchaseOrderReceivingStatusDetails> PurchaseOrderReceivingStatusDetailsList { get; set; }


    }
}
