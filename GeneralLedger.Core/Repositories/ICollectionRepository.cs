using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        IEnumerable<Collection> GetCollectionWithJournalEntry(int Id);
        IEnumerable<Collection> GetCollectionWithSaleBank(string criteria);
    }
}
