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

        public IGLTranRepository GLTran { get; set; }

        public ICoaRepository Coa { get; set; }

        public ICoaSubRepository CoaSub { get; set; }

        public IGLTranDetailRepository GLTranDetail { get; set; }

        public ICollectionRepository Collection { get; set; }

        public ISalesCustomerLedgerRepository SalesCustomerLedger { get; set; }

        public IPurchaseRepository Purchase { get; set; }

        public IPurchaseCustomerLedgerRepository PurchaseCustomerLedger { get; set; }

        public IAccountsReceivableAdjustmentsTypeRepository AccountsReceivableAdjustmentsType { get; set; }

        public IAccountReceivableAdjustmentsRepository AccountsReceivableAdjustments { get; set; }

        public UnitOfWork(GeneralLedgerContext generalLedgerContext)
        {
            _generalLedgerContext = generalLedgerContext;
            Sale = new SaleRepository(_generalLedgerContext);
            JournalEntry = new JournalEntryRepository(_generalLedgerContext);
            Agent = new AgentRepository(_generalLedgerContext);
            GLTran = new GLTranRepository(_generalLedgerContext);
            Coa = new CoaRepository(_generalLedgerContext);
            CoaSub = new CoaSubRepository(_generalLedgerContext);
            GLTranDetail = new GLTranDetailRepository(_generalLedgerContext);
            Collection = new CollectionRepository(_generalLedgerContext);
            SalesCustomerLedger = new SalesCustomerLedgerRepository(_generalLedgerContext);
            Purchase = new PurchaseRepository(_generalLedgerContext);
            PurchaseCustomerLedger = new PurchaseCustomerLedgerRepository(_generalLedgerContext);
            AccountsReceivableAdjustmentsType = new AccountsReceivableAdjustmentsTypeRepository(_generalLedgerContext);
            AccountsReceivableAdjustments = new AccountReceivableAdjustmentsRepository(_generalLedgerContext);

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
