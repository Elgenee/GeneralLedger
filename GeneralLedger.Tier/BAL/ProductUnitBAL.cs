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
    public class ProductUnitBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var productUnit = new ProductUnit
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(productUnit);
            ProductUnitDAL pbDAL = new ProductUnitDAL();
            return pbDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<ProductUnit> getProductUnit()
        {

            ProductUnitDAL pbDAL = new ProductUnitDAL();
            return pbDAL.getProductUnit();
        }
    }
}
