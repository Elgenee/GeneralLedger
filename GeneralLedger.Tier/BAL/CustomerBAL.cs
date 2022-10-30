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
    public class CustomerBAL
    {

        public string Manage(Customer customer, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(customer);

            CustomerDAL customerDAL = new CustomerDAL();
            return customerDAL.manage(ojectToXml, transactionType);
           
        }

        public List<Customer> getCustomer(string criteria)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            return customerDAL.getCustomer(criteria);
        }
    }
}
