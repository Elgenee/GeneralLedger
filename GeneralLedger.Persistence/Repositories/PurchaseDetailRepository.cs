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
    }

}
