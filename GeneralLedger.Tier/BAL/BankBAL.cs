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
    public class BankBAL
    {

        public List<Currency> getCurrency() {

            BankDAL bankDal = new BankDAL();
            return bankDal.getCurrency();
        }


        public string Manage(Bank bank, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(bank);
            BankDAL bankDAL = new BankDAL();

            return bankDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public List<Bank> getBank(string criteria)
        {
            BankDAL bankDal = new BankDAL();
            return bankDal.getBank(criteria);
        }
    }
}
