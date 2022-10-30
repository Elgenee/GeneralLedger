using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public string PONumber { get; set; }
        public int SupplierID { get; set; }
        public int LocationID { get; set; }
        public string DatePurchased { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalReceived { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal GrandTotal { get; set; }
        public bool HasPayment { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public bool AddBalanceToSupplier { get; set; }
        public bool Approved { get; set; }
        public int CreatedBy { get; set; }
        public List<Product> ListOfProduct { get; set; }

        public Location Location { get; set; }
        public Supplier Supplier { get; set; }



    }
}
