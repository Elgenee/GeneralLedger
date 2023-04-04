using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IAccountsPayableAdjustmentsTypeServices
    {

        AccountsPayableAdjustmentsType Add(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType);
        AccountsPayableAdjustmentsType Update(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType);
        void Remove(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType);
        List<AccountsPayableAdjustmentsType> GetAll();
    }
}
