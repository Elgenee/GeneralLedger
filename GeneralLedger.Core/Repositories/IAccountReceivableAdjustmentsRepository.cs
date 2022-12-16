using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Repositories
{
    public interface IAccountReceivableAdjustmentsRepository : IRepository<AccountReceivableAdjustment>
    {
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id);
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria);
    }
}
