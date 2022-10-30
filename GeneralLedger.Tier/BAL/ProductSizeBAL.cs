using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.DAL;
using GeneralLedger.Utility;


namespace GeneralLedger.Tier.BAL
{
    public class ProductSizeBAL
    {
        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var productSize = new ProductSize
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productSize);
            ProductSizeDAL psDAL = new ProductSizeDAL();
            return psDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<ProductSize> getProductSize()
        {

            ProductSizeDAL psDAL = new ProductSizeDAL();
            return psDAL.getProductSize();
        }
    }
}
