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
    public class SupplierBAL
    {

        public string Manage(Supplier supplier, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(supplier);
            SupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.manage(ojectToXml, transactionType);
            //BankDAL bankDAL = new BankDAL();

            //return bankDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }

        public List<Supplier> getSupplier(string criteria)
        {
            SupplierDAL supplierDAL = new SupplierDAL();
            return supplierDAL.getSupplier(criteria);
        }
    }
}
