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
        public int ProductCategoryID { get; set; }
        public int ProductTypeID { get; set; }
        public int ProductBrandID { get; set; }
        public decimal PerPieceBox { get; set; }
        public int LocationID { get; set; }

        public Nullable<int> intTotal { get; set; }
        public Nullable<int> intIDPriceType { get; set; }
        public int ProductCharacteristicID { get; set; }
        public Nullable<int> intIDSize { get; set; }
        public Nullable<int> intIDColor { get; set; }
        public string strCode { get; set; }
        public string strPR { get; set; }
        public string strPCD { get; set; }
        public string strMFLM { get; set; }
        public string strPattern { get; set; }
        public string strOffsetCenterBase { get; set; }
        public string strOrigin { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int intRemainingCount { get; set; }
        public PriceType PriceType { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductCharacteristic ProductCharacteristic { get; set; }
        public ProductType ProductType { get; set; }
        public Location Location { get; set; }
        public List<SearchProductAndColorAndSize> ProductDetails { get; set; }
        public  ProductColor ProductColor { get; set; }
        public  ProductSize ProductSize { get; set; }
        public ProductUnit ProductUnit { get; set; }

    }
}
