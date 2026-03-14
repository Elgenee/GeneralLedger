using System.Collections.Generic;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface ISupplierServices
    {
        IEnumerable<Supplier> GetSuppliers(string criteria);
        Supplier GetSupplierById(int id);
    }
}