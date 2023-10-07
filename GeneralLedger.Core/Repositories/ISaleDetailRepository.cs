using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface ISaleDetailRepository : IRepository<SalesDetail>
    {
        IEnumerable<Sale> GetSalesDetailProductBySalesId(int Id);

    }
}
