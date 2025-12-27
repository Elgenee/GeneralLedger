using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IAccountReceivableAdjustmentsDetailsServices
    {

        AccountReceivableAdjustmentsDetail Add(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail);

        AccountReceivableAdjustmentsDetail Update(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail);

        void Remove(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail);

        List<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetail();

        IEnumerable<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetail(int Id);

        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(int Id);

    }
}
