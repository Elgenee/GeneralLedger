using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class AccountsPayableAdjustmentsDetailRepository : Repository<AccountPayableAdjustmentsDetail>, IAccountsPayableAdjustmentsDetailRepository
    {

        public AccountsPayableAdjustmentsDetailRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(int Id)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
                 .Include(p => p.AccountPayableAdjustmentsDetails)
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductCharacteristic))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductCategory))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductType))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductBrand))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductColor))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductSize))
                 .Include(p => p.AccountPayableAdjustmentsDetails.Select(pd => pd.Product.ProductUnit))
                 .Where(p => p.Id == Id)
                 .ToList();
        }

        public IEnumerable<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetailReturnPurchase(int ProductId, int PurchaseId)
        {
            return GeneralLedgerContext.AccountPayableAdjustmentsDetails
                .Include(p => p.AccountPayableAdjustment)
                .Where(p =>p.ProductId == ProductId && p.AccountPayableAdjustment.PurchaseId == PurchaseId)
                .ToList();
        }
    }
}
