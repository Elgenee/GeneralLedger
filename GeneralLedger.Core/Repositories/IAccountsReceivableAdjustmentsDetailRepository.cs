using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Repositories
{
    public interface IAccountsReceivableAdjustmentsDetailRepository : IRepository<AccountReceivableAdjustmentsDetail>
    {

        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(int Id);

        IEnumerable<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetailReturnSales(int ProductId, int SaleId);
    }
}
