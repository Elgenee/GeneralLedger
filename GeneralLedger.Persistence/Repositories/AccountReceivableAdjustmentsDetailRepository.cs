using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace GeneralLedger.Persistence.Repositories
{
    public class AccountReceivableAdjustmentsDetailRepository : Repository<AccountReceivableAdjustmentsDetail>, IAccountsReceivableAdjustmentsDetailRepository
    {

        public AccountReceivableAdjustmentsDetailRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }


        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(int Id)
        {
            return GeneralLedgerContext.AccountReceivableAdjustments
            .Include(p => p.AccountReceivableAdjustmentsDetails)
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductCharacteristic))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductCategory))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductType))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductBrand))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductColor))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductSize))
            .Include(p => p.AccountReceivableAdjustmentsDetails.Select(pd => pd.Product.ProductUnit))
            .Where(p => p.Id == Id)
            .ToList();
        }

        public IEnumerable<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetailReturnSales(int ProductId, int SaleId)
        {
            return GeneralLedgerContext.AccountReceivableAdjustmentsDetails
              .Include(p => p.AccountReceivableAdjustment)
              .Where(p => p.ProductId == ProductId && p.AccountReceivableAdjustment.SalesId == SaleId)
              .ToList();
        }
    }
}
