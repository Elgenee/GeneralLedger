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
    public class ProductTypeBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var productType = new ProductType
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productType);
            ProductTypeDAL ptDAL = new ProductTypeDAL();
            return ptDAL.manage(ojectToXml, transactionType);

            //return string.Empty;
        }

        public List<ProductType> getProductType()
        {

            ProductTypeDAL ptDAL = new ProductTypeDAL();
            return ptDAL.getProductType();
        }

    }
}
