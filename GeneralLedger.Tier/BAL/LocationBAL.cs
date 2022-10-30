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
    public class LocationBAL
    {

        public string Manage(Location location, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(location);
            //ProductDAL pbDAL = new ProductDAL();
            LocationDAL locationDAL = new LocationDAL();
            return locationDAL.manage(ojectToXml, transactionType);
            //return pbDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<Location> getLocation()
        {
            LocationDAL locationDAL = new LocationDAL();
            return locationDAL.getLocation();
        }
    }
}
