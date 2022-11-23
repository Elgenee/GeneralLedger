using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface ISaleRepository : IRepository<Sale>
    {
        IEnumerable<Sale> GetSaleWithJournalEntry(int Id);

        IEnumerable<Sale> GetSaleWithCustomerAgent(string criteria);

        Sale GetSaleWithCustomerAgent(int Id);

    }
}
