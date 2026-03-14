using System;
using System.Collections.Generic;
using GeneralLedger.Core.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Core.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetSuppliers(string criteria);
        Supplier GetSupplierById(int id);
    }
}
