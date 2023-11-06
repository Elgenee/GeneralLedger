using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository 
    { 
    
        //fix this
        public ProductRepository(GeneralLedgerContext context) : base(context)
        {

        }
        //fix this
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public Product GetProductWithCategoryTypeBrandsSizeColorUnitCharacteristic(int id)
        {
            return GeneralLedgerContext.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductSize)
                .Include(p => p.ProductColor)
                .Include(p => p.PriceType)
                .Include(p => p.ProductCharacteristic)
                .Include(p => p.ProductUnit)
                .Where(p => p.Id == id)
                .SingleOrDefault();
        }
        //fix this


    }
   
}
