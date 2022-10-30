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
    public class PurchaseOrderReceivingBAL
    {


        public List<PurchaseOrderReceivingStatusDetails> GetPurchaseOrderReceivingStatusDetails(int PurchaseOrderID) {

            PurchaseOrderReceivingDAL purchaseOrderReceivingDAL = new PurchaseOrderReceivingDAL();
            return purchaseOrderReceivingDAL.GetPurchaseOrderReceivingStatusDetails(PurchaseOrderID);

        }

       
        public string Manage(PurchaseOrderReceiving purchaseOrderReceiving, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(purchaseOrderReceiving);
            PurchaseOrderReceivingDAL purchaseOrderReceivingDAL = new PurchaseOrderReceivingDAL();

            return purchaseOrderReceivingDAL.manage(ojectToXml , transactionType);
            //SupplierDAL supplierDAL = new SupplierDAL();
            //return supplierDAL.manage(ojectToXml, transactionType);
            //BankDAL bankDAL = new BankDAL();

            //return bankDAL.manage(ojectToXml, transactionType);
            //PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            //return purOrdDAL.manage(ojectToXml, transactionType);

        }
    }
}
