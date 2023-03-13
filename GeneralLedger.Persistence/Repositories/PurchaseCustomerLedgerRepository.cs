using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class PurchaseCustomerLedgerRepository : Repository<PurchaseSupplierLedger> , IPurchaseSupplierLedgerRepository
    {

        public PurchaseCustomerLedgerRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<spGetPurchaseSupplierLedger_Result> GetPurchaseSupplierLedger(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
