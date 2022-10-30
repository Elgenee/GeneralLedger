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
    public class ProductColorBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var productColor = new ProductColor
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productColor);
            ProductColorDAL pcDAL = new ProductColorDAL();
            return pcDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<ProductColor> getProductColor()
        {

            ProductColorDAL pcDAL = new ProductColorDAL();
            return pcDAL.getProductColor();
        }
    }
}
