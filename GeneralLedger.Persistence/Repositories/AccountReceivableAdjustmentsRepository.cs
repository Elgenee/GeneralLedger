using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class AccountReceivableAdjustmentsRepository : Repository<AccountReceivableAdjustment>, IAccountReceivableAdjustmentsRepository
    {

        public AccountReceivableAdjustmentsRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
