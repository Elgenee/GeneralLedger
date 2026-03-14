using System.Collections.Generic;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class SupplierServices : ISupplierServices
    {
        public IEnumerable<Supplier> GetSuppliers(string criteria)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Supplier.GetSuppliers(criteria);
            }
        }

        public Supplier GetSupplierById(int id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Supplier.GetSupplierById(id);
            }
        }
    }
}