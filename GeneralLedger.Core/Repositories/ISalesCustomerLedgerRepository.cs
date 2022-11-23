using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface ISalesCustomerLedgerRepository : IRepository<SalesCustomerLedger>
    {
        IEnumerable<spGetSalesCustomerLedger_Result> GetSalesCustomerLedger(int Id);
    }
}
