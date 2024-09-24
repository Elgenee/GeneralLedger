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
    public class ProductBAL
    {

        public List<ProductCharacteristic> getProductCharacteristic()
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getProductCharacteristic();
        }


        public List<Location> getLocation()
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getLocation();
        }


        public List<SearchProductAndColorAndSize> getProductDetails(int ProductID)
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getProductDetails(ProductID);
        }

        public List<Product> getProductSearch(string criteria)
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getProductSearch(criteria);
        }


        public List<Product> getReturnPurchaseProductSearch(string criteria , int purchaseId)
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getReturnPurchaseProductSearch(criteria , purchaseId);
        }

        public List<Product> getReturnSalesProductSearch(string criteria, int salesId)
        {

            ProductDAL pbDAL = new ProductDAL();
            return pbDAL.getReturnSalesProductSearch(criteria, salesId);
        }


        public string Manage(Product product, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(product);
            ProductDAL pbDAL = new ProductDAL();

            return pbDAL.manage(ojectToXml, transactionType);
            //return string.Empty;
        }


        public string ManageProductDetail(SearchProductAndColorAndSize searchProductAndColorAndSize, string transactionType)
        {
            string ojectToXml = CommonUtil.toXML(searchProductAndColorAndSize);
            ProductDAL pbDAL = new ProductDAL();

            return pbDAL.ManageProductDetail(ojectToXml, transactionType);
           // return string.Empty;
        }
    }
}
