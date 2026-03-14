using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class AccountReceivableAdjustmentsDetailServices : IAccountReceivableAdjustmentsDetailsServices
    {
        public AccountReceivableAdjustmentsDetail Add(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }

        public List<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetail()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountReceivableAdjustmentsDetail> GetAccountReceivableAdjustmentsDetail(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsReceivableAdjustmentsDetail.GetAccountReceivableAdjustmentsDetailProductByAccountReceivableAdjustmentId(Id);
            }
        }

        public void Remove(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }

        public AccountReceivableAdjustmentsDetail Update(AccountReceivableAdjustmentsDetail accountReceivableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }
    }
}
