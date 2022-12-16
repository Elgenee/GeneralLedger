using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        IEnumerable<Purchase> GetPurchasesWithJournalEntry(int Id);
        IEnumerable<Purchase> GetPurchaseWithSupplier(string criteria);
        Purchase GetPurchaseWithSupplier(int Id);

    }
}
