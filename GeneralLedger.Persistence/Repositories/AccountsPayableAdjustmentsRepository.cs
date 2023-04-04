using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class AccountsPayableAdjustmentsRepository : Repository<AccountPayableAdjustment>, IAccountsPayableAdjustmentsRepository
    {

        public AccountsPayableAdjustmentsRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDMCM(string criteria)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
                 .Include(a => a.tblGLTranHeaders)
                 .Include(a => a.AccountsPayableAdjustmentsType)
                 .Include(a => a.Supplier)
                 .Where(a => (a.TransactionNo.ToLower().Contains(criteria.ToLower())
                || a.Supplier.strName.ToLower().Contains(criteria.ToLower()))
                && (a.AccountsPayableAdjustmentTypeId == 2 || a.AccountsPayableAdjustmentTypeId == 3)).ToList().Take(100);
        }


        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPaymentPurchases(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
                 .Include(a => a.tblGLTranHeaders)
                 .Include(a => a.AccountsPayableAdjustmentsType)
                 .Include(a => a.Payment)
                 .Include(a => a.Payment.Purchase)
                 .Include(a => a.Payment.Bank)
                 .Include(a => a.Payment.Purchase.Supplier)
                 .Where(a => (a.TransactionNo.ToLower().Contains(criteria.ToLower())
                || a.Payment.Purchase.Supplier.strName.ToLower().Contains(criteria.ToLower())
                || a.Payment.PaymentCV.ToLower().Contains(criteria.ToLower()))
                && a.AccountsPayableAdjustmentTypeId == intIdAccountsPayableAdjustmentsType).ToList().Take(100);

            //return new List<AccountPayableAdjustment>();
        }

        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithSupplier(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
                 .Include(a => a.tblGLTranHeaders)
                 .Include(a => a.AccountsPayableAdjustmentsType)
                 .Include(a => a.Supplier)
                 .Where(a => (a.TransactionNo.ToLower().Contains(criteria.ToLower())
                || a.Supplier.strName.ToLower().Contains(criteria.ToLower()))
                && a.AccountsPayableAdjustmentTypeId == intIdAccountsPayableAdjustmentsType).ToList().Take(100);
        }

        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithJournalEntry(int Id)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
               .Include(a => a.tblGLTranHeaders)
                .Include(a => a.tblGLTranHeaders.Select(h => h.tblGLTranDetails))
                .Include(a => a.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
                .Include(a => a.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
                .Where(s => s.Id == Id)
                .ToList();
        }
        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPurchases(string criteria, int intIdAccountsPayableAdjustmentsType)
        {
            return GeneralLedgerContext.AccountPayableAdjustments
             .Include(a => a.tblGLTranHeaders)
             .Include(a => a.AccountsPayableAdjustmentsType)
             .Include(a => a.Purchase)
             .Include(a => a.Purchase.Supplier)
             .Where(a => (a.TransactionNo.ToLower().Contains(criteria.ToLower())
            || a.Payment.Purchase.Supplier.strName.ToLower().Contains(criteria.ToLower())
            || a.Payment.PaymentCV.ToLower().Contains(criteria.ToLower()))
            && a.AccountsPayableAdjustmentTypeId == intIdAccountsPayableAdjustmentsType).ToList().Take(100);
        }


    }
}
