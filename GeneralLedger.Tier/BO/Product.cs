using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal PerPieceBox { get; set; }
        public int ProductCharacteristicID { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductTypeID { get; set; }
        public int ProductBrandID { get; set; }
        public int LocationID { get; set; }


        public ProductCharacteristic ProductCharacteristic { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductType ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public Location Location { get; set; }
        public List<SearchProductAndColorAndSize> ProductDetails { get; set; }


    }
}
