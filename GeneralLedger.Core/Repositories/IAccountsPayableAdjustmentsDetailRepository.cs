using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Repositories
{
    public interface IAccountsPayableAdjustmentsDetailRepository : IRepository<AccountPayableAdjustmentsDetail>
    {
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(int Id);


        IEnumerable<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetailReturnPurchase(int ProductId, int PurchaseId);

    }
}
