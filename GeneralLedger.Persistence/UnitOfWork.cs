using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core;
using GeneralLedger.Core.Repositories;
using GeneralLedger.Persistence.Repositories;

namespace GeneralLedger.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeneralLedgerContext _generalLedgerContext { get; set; }

        public ISaleRepository Sale { get; set; }

        public IJournalEntryRepository JournalEntry { get; set; }

        public IAgentRepository Agent { get; set; }

        public UnitOfWork(GeneralLedgerContext generalLedgerContext)
        {
            _generalLedgerContext = generalLedgerContext;
            Sale = new SaleRepository(_generalLedgerContext);
            JournalEntry = new JournalEntryRepository(_generalLedgerContext);

        }
        public int Complete()
        {
            return _generalLedgerContext.SaveChanges();
        }

        public void Dispose()
        {
            _generalLedgerContext.Dispose();
        }
    }
}
