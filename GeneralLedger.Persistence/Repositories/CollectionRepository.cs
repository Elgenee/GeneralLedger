using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class CollectionRepository : Repository<Collection>, ICollectionRepository
    {
        public CollectionRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Collection> GetCollectionWithJournalEntry(int Id)
        {
            return GeneralLedgerContext.Collections
                .Include(c => c.tblGLTranHeaders)
                .Include(c => c.tblGLTranHeaders.Select(h => h.tblGLTranDetails))
                .Include(c => c.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
                .Include(c => c.tblGLTranHeaders.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
                .Where(s => s.Id == Id)
                .ToList();
        }

        public IEnumerable<Collection> GetCollectionWithSaleBank(string criteria)
        {
            return GeneralLedgerContext.Collections
                .Include(c => c.Sale)
                .Include(c => c.Sale.Customer)
                .Include(c => c.Bank)
                .Include(s => s.tblGLTranHeaders)
                .Where(c => c.TRANo.ToLower().Contains(criteria.ToLower())
                || c.Sale.Customer.strName.ToLower().Contains(criteria.ToLower())
                || c.Sale.PONo.ToLower().Contains(criteria.ToLower())
                || c.Sale.TRANo.ToLower().Contains(criteria.ToLower()))
                .Take(100).ToList();
        }
    }
}
