using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Repositories;


namespace GeneralLedger.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISaleRepository Sale { get; }
        IJournalEntryRepository JournalEntry { get; }
        IAgentRepository Agent { get; }
        IGLTranRepository GLTran { get; }
        ICoaRepository Coa { get; }
        ICoaSubRepository CoaSub { get; }
        IGLTranDetailRepository GLTranDetail { get; }
        ICollectionRepository Collection{ get; }
        ISalesCustomerLedgerRepository SalesCustomerLedger { get; }

        int Complete();
    }
}
