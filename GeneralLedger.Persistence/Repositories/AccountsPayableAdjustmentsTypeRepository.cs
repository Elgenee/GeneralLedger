using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class AccountsPayableAdjustmentsTypeRepository : Repository<AccountsPayableAdjustmentsType> , IAccountsPayableAdjustmentsTypeRepository
    {

        public AccountsPayableAdjustmentsTypeRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }
    }
}
