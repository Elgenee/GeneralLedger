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
    public class ProductCategoryBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType) {

            int intParser;

            var productCategory = new ProductCategory {
                 ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                 Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productCategory);
            ProductCategoryDAL pcDAL = new ProductCategoryDAL();
            return pcDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<ProductCategory> getProductCategory()
        {

            ProductCategoryDAL pcDAL = new ProductCategoryDAL();
            return pcDAL.getProductCategory();
        }

        public List<ProductCategory> getProductCategoryByCriteria(string criteria)
        {

            ProductCategoryDAL pcDAL = new ProductCategoryDAL();
            return pcDAL.getProductCategoryByCriteria(criteria);
        }
    }
}
