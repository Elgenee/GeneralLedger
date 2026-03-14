using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(GeneralLedgerContext context) : base(context)
        {
        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Supplier> GetSuppliers(string criteria)
        {
            return GeneralLedgerContext.Suppliers
                .Where(s => s.strName.ToLower().Contains(criteria.ToLower()))
                .ToList();
        }

        public Supplier GetSupplierById(int id)
        {
            return GeneralLedgerContext.Suppliers
                .FirstOrDefault(s => s.Id == id);
        }
    }
}