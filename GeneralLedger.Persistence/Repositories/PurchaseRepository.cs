using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {

        public PurchaseRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Purchase> GetPurchasesWithJournalEntry(int Id)
        {
            return GeneralLedgerContext.Purchases
                .Include(s => s.tblGLTranHeaders)
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails))
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
                .AsQueryable()
                .Where(s => s.Id == Id)
                .ToList();
        }

        public IEnumerable<Purchase> GetPurchaseWithoutReturnPurchases(string criteria)
        {
            return GeneralLedgerContext.Purchases
                 .Include(p => p.Supplier)
                 .Include(p => p.tblGLTranHeaders)
                 .AsQueryable()
                 .Where(p => (p.PONo.ToLower().Contains(criteria.ToLower())
                 || p.TRANo.ToLower().Contains(criteria.ToLower())
                 || p.Supplier.strName.ToLower().Contains(criteria.ToLower())
                 || p.SIDR.ToLower().Contains(criteria.ToLower())) &&
                 ((p.AccountPayableAdjustments.Count > 0 && p.AccountPayableAdjustments.Any(a => a.AccountsPayableAdjustmentTypeId != 4))
                 || p.AccountPayableAdjustments.Count == 0))
                 .ToList().Take(100);
        }

        public IEnumerable<Purchase> GetPurchaseWithSupplier(string criteria)
        {
            return GeneralLedgerContext.Purchases
                .Include(p => p.Supplier)
                .Include(p => p.tblGLTranHeaders)
                .Include(p => p.AccountPayableAdjustments)
                .AsQueryable()
                .Where(p => p.PONo.ToLower().Contains(criteria.ToLower())
                || p.TRANo.ToLower().Contains(criteria.ToLower())
                || p.Supplier.strName.ToLower().Contains(criteria.ToLower())
                || p.SIDR.ToLower().Contains(criteria.ToLower()))
                .ToList().Take(100);
        }

        public Purchase GetPurchaseWithSupplier(int Id)
        {
            return GeneralLedgerContext.Purchases
             .Include(p => p.Supplier)
             .Include(p => p.tblGLTranHeaders)
             .AsQueryable()
             .Where(p => p.Id == Id)
             .SingleOrDefault();
        }
    }
}
