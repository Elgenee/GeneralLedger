using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IAccountPayableAdjustmentsDetailsServices
    {

        AccountPayableAdjustmentsDetail Add(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail);

        AccountPayableAdjustmentsDetail Update(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail);

        void Remove(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail);

        List<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetail();

        IEnumerable<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetail(int Id);

        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(int Id);

        //TODO:Finish this so that it will used in searching in accounts payable


    }
}
