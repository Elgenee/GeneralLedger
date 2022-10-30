using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class PurchaseOrderReceivingStatusDetails
    {

        public int PurchaseOrderDetailID { get; set; }

        public string ProductName { get; set; }

        public int ProductID { get; set; }
        public int ProductColorID { get; set; }
        public int ProductSizeID { get; set; }
        public ProductColor ProductColor { get; set; }
        public ProductSize ProductSize { get; set; }
        public int ReceivingStatusID { get; set; }
        public ReceivingStatus ReceivingStatus { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int QuantityReceived { get; set; }
        public int QuantityRemaining { get; set; }

        public int AddedQuantityReceived { get; set; } //Pila ang napuno
        public int CurStock { get; set; }
        public int ActStock { get; set; }

        public bool IsReceived { get; set; }
    }
}
