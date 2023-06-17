using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class SearchProductAndColorAndSize
    {

        public int ID { get; set; }

        public int ProductID { get; set; }

        public int ProductColorID { get; set; }
        public int ProductSizeID { get; set; }
        public ProductColor ProductColor { get; set; }
        public ProductSize ProductSize { get; set; }
        public decimal Mininum { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public int QuantityReceived { get; set; }
        public int QuantityRemaining { get; set; }
        public decimal Subtotal { get; set; }
        public int CurStock { get; set; }
        public int ActStock { get; set; }

    }
}
