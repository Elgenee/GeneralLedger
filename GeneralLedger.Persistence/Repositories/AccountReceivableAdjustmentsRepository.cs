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

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDMCM(string criteria)
        {

            return GeneralLedgerContext.AccountReceivableAdjustments
                .Include(aj => aj.tblGLTranHeaders)
                .Include(aj => aj.AccountsReceivableAdjustmentsType)
                .Include(aj => aj.Customer)
                .Include(aj => aj.Sale)
                //.Include(aj => aj.Collection.Sale)
                //.Include(aj => aj.Collection.Bank)
                //.Include(aj => aj.Collection.Sale.Customer)
                .Where(aj => (aj.TransactionNo.ToLower().Contains(criteria.ToLower())
                || aj.Customer.strName.ToLower().Contains(criteria.ToLower()))
                && (aj.AccountsReceivableAdjustmentsTypeId == 2 || aj.AccountsReceivableAdjustmentsTypeId == 3)).ToList().Take(100);
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria, int intIdAccountsReceivableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountReceivableAdjustments
                .Include(aj => aj.tblGLTranHeaders)
                .Include(aj => aj.AccountsReceivableAdjustmentsType)
                .Include(aj => aj.Collection)
                .Include(aj => aj.Collection.Sale)
                .Include(aj => aj.Collection.Bank)
                .Include(aj => aj.Collection.Sale.Customer)
                .Where(aj => (aj.TransactionNo.ToLower().Contains(criteria.ToLower())
                || aj.Collection.Sale.Customer.strName.ToLower().Contains(criteria.ToLower())
                || aj.Collection.TRANo.ToLower().Contains(criteria.ToLower()))
                && aj.AccountsReceivableAdjustmentsTypeId == intIdAccountsReceivableAdjustmentsType).ToList().Take(100);
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCustomer(string criteria, int intIdAccountsReceivableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountReceivableAdjustments
                .Include(aj => aj.tblGLTranHeaders)
                .Include(aj => aj.AccountsReceivableAdjustmentsType)
                .Include(aj => aj.Customer)
                //.Include(aj => aj.Sale.Customer)
                //.Include(aj => aj.Collection.Sale)
                //.Include(aj => aj.Collection.Bank)
                //.Include(aj => aj.Collection.Sale.Customer)
                .Where(aj => (aj.TransactionNo.ToLower().Contains(criteria.ToLower())
                || aj.Customer.strName.ToLower().Contains(criteria.ToLower()))
                && aj.AccountsReceivableAdjustmentsTypeId == intIdAccountsReceivableAdjustmentsType).ToList().Take(100);
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id)
        {
            return GeneralLedgerContext.AccountReceivableAdjustments
                .Include(aj => aj.tblGLTranHeaders)
                .Include(aj => aj.tblGLTranHeaders.Select(h => h.tblGLTranDetails))
                .Include(aj => aj.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
                .Include(aj => aj.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
                .Where(s => s.Id == Id)
                .ToList();

        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithSales(string criteria, int intIdAccountsReceivableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountReceivableAdjustments
               .Include(aj => aj.tblGLTranHeaders)
               .Include(aj => aj.AccountsReceivableAdjustmentsType)
               .Include(aj => aj.Sale)
               .Include(aj => aj.Sale.Customer)
               //.Include(aj => aj.Collection.Sale)
               //.Include(aj => aj.Collection.Bank)
               //.Include(aj => aj.Collection.Sale.Customer)
               .Where(aj => (aj.TransactionNo.ToLower().Contains(criteria.ToLower())
               || aj.Sale.Customer.strName.ToLower().Contains(criteria.ToLower())
               || aj.Sale.TRANo.ToLower().Contains(criteria.ToLower()))
               && aj.AccountsReceivableAdjustmentsTypeId == intIdAccountsReceivableAdjustmentsType).ToList().Take(100);
        }
    }
}
