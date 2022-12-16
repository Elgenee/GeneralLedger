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
    public class AccountsReceivableAdjustmentsTypeServices : IAccountsReceivableAdjustmentsTypeServices
    {
        public AccountsReceivableAdjustmentsType Add(AccountsReceivableAdjustmentsType accountsReceivableAdjustmentsType)
        {
            throw new NotImplementedException();
        }

        public List<AccountsReceivableAdjustmentsType> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustmentsType.GetAll().ToList();
            }

        }

        public void Remove(AccountsReceivableAdjustmentsType accountsReceivableAdjustmentsType)
        {
            throw new NotImplementedException();
        }

        public AccountsReceivableAdjustmentsType Update(AccountsReceivableAdjustmentsType accountsReceivableAdjustmentsType)
        {
            throw new NotImplementedException();
        }
    }
}
