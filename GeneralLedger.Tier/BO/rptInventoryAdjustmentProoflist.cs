using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptInventoryAdjustmentProoflist
    {
        public string strTransactionNumber { get; set; }
        public string datTransactionDate { get; set; }
        public string strAdjustmentType { get; set; }
        public string strDescription { get; set; }

        // Product Information
        public string strProductCode { get; set; }
        public string strProductName { get; set; }
        public string strProductDescription { get; set; }

        // Product Brand
        public string strBrand { get; set; }

        // Product Category
        public string strCategory { get; set; }

        // Product Type
        public string strProductType { get; set; }

        // Product Characteristic
        public string strCharacteristic { get; set; }

        // Product Color
        public string strColor { get; set; }

        // Product Size
        public string strSize { get; set; }

        // Additional Product Details
        public string strPR { get; set; }
        public string strPCD { get; set; }
        public string strMFLM { get; set; }
        public string strPattern { get; set; }
        public string strOrigin { get; set; }

        // Transaction Details
        public decimal decQuantity { get; set; }
        public decimal curUnitPrice { get; set; }
        public decimal curTotalPrice { get; set; }

        // IDs for reference
        public int intAdjustmentId { get; set; }
        public int intAdjustmentTypeId { get; set; }
        public int intProductId { get; set; }
    }
}
