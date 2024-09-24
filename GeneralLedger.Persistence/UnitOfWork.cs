using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core;
using GeneralLedger.Core.Repositories;
using GeneralLedger.Persistence.Repositories;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace GeneralLedger.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public GeneralLedgerContext _generalLedgerContext { get; set; }

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

        public IPurchaseSupplierLedgerRepository PurchaseSupplierLedger { get; set; }

        public IAccountsReceivableAdjustmentsTypeRepository AccountsReceivableAdjustmentsType { get; set; }

        public IAccountReceivableAdjustmentsRepository AccountsReceivableAdjustments { get; set; }

        public IPaymentRepository Payment { get; set; }

        public IUserRepository User { get; set; }

        public IRoleRepository Role { get; set; }

        public IUserRoleRepository UserRole { get; set; }

        public ItblTBBatchHdrRepository tblTBBatchHdr { get; set; }

        public IAccountsPayableAdjustmentsTypeRepository AccountsPayableAdjustmentsType { get; set; }

        public IAccountsPayableAdjustmentsRepository AccountsPayableAdjustments { get; set; }

        public IAccountsPayableAdjustmentsDetailRepository AccountsPayableAdjustmentsDetail { get; set; }
        //Products Repository
        public IProductRepository Products { get; set; }

        public IStockRepository Stock { get; set; }

        public IPurchaseDetailRepository PurchaseDetail { get; set; }

        public ISaleDetailRepository SaleDetail { get; set; }

        public IAccountsReceivableAdjustmentsDetailRepository AccountsReceivableAdjustmentsDetail { get; set; }

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
            PurchaseSupplierLedger = new PurchaseCustomerLedgerRepository(_generalLedgerContext);
            AccountsReceivableAdjustmentsType = new AccountsReceivableAdjustmentsTypeRepository(_generalLedgerContext);
            AccountsReceivableAdjustmentsDetail = new AccountReceivableAdjustmentsDetailRepository(_generalLedgerContext);
            AccountsReceivableAdjustments = new AccountReceivableAdjustmentsRepository(_generalLedgerContext);
            Payment = new PaymentRepository(_generalLedgerContext);
            User = new UserRepository(_generalLedgerContext);
            Role = new RoleRepository(_generalLedgerContext);
            UserRole = new UserRoleRepository(_generalLedgerContext);
            tblTBBatchHdr = new tblTBBatchHdrRepository(_generalLedgerContext);
            AccountsPayableAdjustments = new AccountsPayableAdjustmentsRepository(_generalLedgerContext);
            AccountsPayableAdjustmentsDetail = new AccountsPayableAdjustmentsDetailRepository(_generalLedgerContext);
            AccountsPayableAdjustmentsType = new AccountsPayableAdjustmentsTypeRepository(_generalLedgerContext);
            Products = new ProductRepository(_generalLedgerContext);
            Stock = new StockRepository(_generalLedgerContext);
            PurchaseDetail = new PurchaseDetailRepository(_generalLedgerContext);
            SaleDetail = new SaleDetailRepository(_generalLedgerContext);
    

        }
        public int Complete()
        {
            return _generalLedgerContext.SaveChanges();
        }

        public void Dispose()
        {
            _generalLedgerContext.Dispose();
        }

        public EntityState GetEntityState<TEntity>(TEntity entity) where TEntity : class
        {
            return _generalLedgerContext.Entry(entity).State;
        }
    }
}
