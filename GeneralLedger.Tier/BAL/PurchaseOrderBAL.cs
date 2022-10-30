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
    public class PurchaseOrderBAL
    {
        public List<Product> getProductSearch(string criteria, int ProductCategoryID, int ProductBrandID, int ProductTypesID)
        {
            PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            return purOrdDAL.getProductSearch(criteria, ProductCategoryID, ProductBrandID, ProductTypesID);
        }


        public List<PurchaseOrder> spGetPurchaseOrderForApproval() {

            PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            return purOrdDAL.spGetPurchaseOrderForApproval();

        }

        public List<PurchaseOrder> spGetPurchaseOrderForPending()
        {

            PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            return purOrdDAL.spGetPurchaseOrderForPending();

        }

        public string Manage(PurchaseOrder purchaseOrder, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(purchaseOrder);
            //SupplierDAL supplierDAL = new SupplierDAL();
            //return supplierDAL.manage(ojectToXml, transactionType);
            //BankDAL bankDAL = new BankDAL();

            //return bankDAL.manage(ojectToXml, transactionType);
            PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            return purOrdDAL.manage(ojectToXml, transactionType);
            
        }


        public string spManageApprovePurchaseOrder(int intIDPO, string transType, int userID) {

            PurchaseOrderDAL purOrdDAL = new PurchaseOrderDAL();
            return purOrdDAL.spManageApprovePurchaseOrder(intIDPO, transType, userID);

        }

    }
}
