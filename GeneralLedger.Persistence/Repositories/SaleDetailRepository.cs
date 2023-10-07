using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class SaleDetailRepository : Repository<SalesDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(DbContext context) : base(context)
        {
        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Sale> GetSalesDetailProductBySalesId(int Id)
        {
            return GeneralLedgerContext.Sales
                .Include(s => s.SalesDetails)
                .Include(s => s.SalesDetails.Select(pd => pd.Product))
                .Include(s => s.SalesDetails.Select(pd => pd.Product.ProductCharacteristic))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductCategory))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductType))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductBrand))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductColor))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductSize))
                .Include(p => p.SalesDetails.Select(pd => pd.Product.ProductUnit))
                .Where(p => p.Id == Id)
                .ToList();
        }
    }
}
