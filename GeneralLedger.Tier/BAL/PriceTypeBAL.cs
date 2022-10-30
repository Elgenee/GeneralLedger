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
    public class PriceTypeBAL
    {

        public string Manage(Dictionary<string, string> param, string transactionType)
        {

            int intParser;

            var priceType = new PriceType
            {
                ID = int.TryParse(param["&ID"], out intParser) ? intParser : 0,
                Name = param["&Name"]

            };

            string ojectToXml = CommonUtil.toXML(priceType);

            PriceTypeDAL priceTypeDAL = new PriceTypeDAL();
            return priceTypeDAL.manage(ojectToXml, transactionType);
            //ProductBrandDAL pbDAL = new ProductBrandDAL();
            //return pbDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }

        public List<PriceType> getPriceType()
        {
            PriceTypeDAL priceTypeDAL = new PriceTypeDAL();
            return priceTypeDAL.getPriceType();
        }
    }
}
