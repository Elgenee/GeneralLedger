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
    public class ProductBrandBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var productBrand = new ProductBrand
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productBrand);
            ProductBrandDAL pbDAL = new ProductBrandDAL();
            return pbDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<ProductBrand> getProductBrand()
        {

            ProductBrandDAL pbDAL = new ProductBrandDAL();
            return pbDAL.getProductBrand();
        }

        public List<ProductBrand> getProductBrandByCriteria(string criteria)
        {

            ProductBrandDAL pbDAL = new ProductBrandDAL();
            return pbDAL.getProductBrandByCriteria(criteria);
        }
    }
}
