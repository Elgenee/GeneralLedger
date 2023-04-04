using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class AccountsPayableAdjustmentsTypeServices : IAccountsPayableAdjustmentsTypeServices
    {
        public AccountsPayableAdjustmentsType Add(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType)
        {
            throw new NotImplementedException();
        }

        public List<AccountsPayableAdjustmentsType> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsPayableAdjustmentsType.GetAll().ToList();
            }
        }

        public void Remove(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType)
        {
            throw new NotImplementedException();
        }

        public AccountsPayableAdjustmentsType Update(AccountsPayableAdjustmentsType accountsPayableAdjustmentsType)
        {
            throw new NotImplementedException();
        }
    }
}
