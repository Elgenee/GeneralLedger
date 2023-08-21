using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class PurchaseDetailRepository : Repository<PurchaseDetail>, IPurchaseDetailRepository
    {
        public PurchaseDetailRepository(GeneralLedgerContext context) : base(context)
        {
        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Purchase> GetPurchaseDetailProductByPurchaseId(int Id)
        {
          return GeneralLedgerContext.Purchases
                .Include(p => p.PurchaseDetails)
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductCharacteristic))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductCategory))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductType))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductBrand))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductColor))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductSize))
                .Include(p => p.PurchaseDetails.Select(pd => pd.Product.ProductUnit))
                .Where(p => p.Id == Id)
                .ToList();
        }
    }

}
