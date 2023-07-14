using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {

        public SaleRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Sale> GetSalesWithoutReturnSales(string criteria)
        {

            return GeneralLedgerContext.Sales
               .Include(s => s.Customer)
               .Include(s => s.Agent)
               .Include(s => s.tblGLTranHeaders)
               .Include(s => s.AccountReceivableAdjustments)
               .Where(s => (s.PONo.ToLower().Contains(criteria.ToLower())
               || s.TRANo.ToLower().Contains(criteria.ToLower())
               || s.Customer.strName.ToLower().Contains(criteria.ToLower())
               || s.Agent.Name.ToLower().Contains(criteria.ToLower())) &&
               ((s.AccountReceivableAdjustments.Count > 0 && s.AccountReceivableAdjustments.Any(a => a.AccountsReceivableAdjustmentsTypeId != 1002))
                || s.AccountReceivableAdjustments.Count == 0))
               .ToList()
               .Take(100);
        }

        public IEnumerable<Sale> GetSaleWithCustomerAgent(string criteria)
        {
            return GeneralLedgerContext.Sales
                .Include(s => s.Customer)
                .Include(s => s.Agent)
                .Include(s => s.tblGLTranHeaders)
                .Include(s => s.AccountReceivableAdjustments)
                .Where(s => (s.PONo.ToLower().Contains(criteria.ToLower())
                || s.TRANo.ToLower().Contains(criteria.ToLower())
                || s.Customer.strName.ToLower().Contains(criteria.ToLower()))).ToList().Take(100);

        }

        public Sale GetSaleWithCustomerAgent(int Id)
        {
            return GeneralLedgerContext.Sales
                .Include(s => s.Customer)
                .Include(s => s.Agent)
                .Include(s => s.tblGLTranHeaders)
                .Where(s => s.Id == Id)
                .SingleOrDefault();
        }

        public IEnumerable<Sale> GetSaleWithJournalEntry(int Id)
        {
            return GeneralLedgerContext.Sales
                .Include(s => s.tblGLTranHeaders)
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails))
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
                .Include(s => s.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
                .Where(s => s.Id == Id)
                .ToList();


        }
    }
}
