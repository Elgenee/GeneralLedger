using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class ProductServices : IProductServices
    {

        public Product Add(Product product)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Products.Add(product);
                unitOfWork.Complete();
                return product;
            }
        }

        public List<Product> GetProduct()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Products.GetAll().ToList();
            }
        }

        public void Remove(Product product)
        {

            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Products.Get(product.Id);
                unitOfWork.Products.Remove(result);
                unitOfWork.Complete();
            }

       
        }

        public Product Update(Product product)
        {
        
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Products.Get(product.Id);
                result.strProductName = product.strProductName;
                result.strDescription = product.strDescription;
                result.intIDProductCategory = product.intIDProductCategory;
                result.intIDProductType = product.intIDProductType;
                result.intIDProductBrands = product.intIDProductBrands;
                result.intPerPiecePerBox = product.intPerPiecePerBox;
                result.intIDLocation = product.intIDLocation;
                result.intTotal = product.intTotal;
                result.intIDPriceType = product.intIDPriceType;
                result.intIDProductCharacteristic = product.intIDProductCharacteristic;
                result.intIDSize = product.intIDSize;
                result.intIDColor = product.intIDColor;
                result.strCode = product.strCode;
                result.strPR= product.strPR;
                result.strPCD = product.strPCD;
                result.strMFLM = product.strMFLM;
                result.strPattern = product.strPattern;
                result.strOrigin = product.strOrigin;
                result.strOffsetCenterBore = product.strOffsetCenterBore;
                result.intIDProductUnit = product.intIDProductUnit;
                result.intRemainingCount = product.intRemainingCount;
                unitOfWork.Complete();
                return result;
            }


        }
    }
}
