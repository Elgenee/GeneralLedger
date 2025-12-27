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
    public class AccountsPayableAdjustmentsDetailServices : IAccountPayableAdjustmentsDetailsServices
    {
        public AccountPayableAdjustmentsDetail Add(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }

        public List<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetail()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountPayableAdjustmentsDetail> GetAccountPayableAdjustmentsDetail(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.AccountsPayableAdjustmentsDetail.GetAccountPayableAdjustmentsDetailProductByAccountPayableAdjustmentId(Id);
            }
        }

        public void Remove(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }

        public AccountPayableAdjustmentsDetail Update(AccountPayableAdjustmentsDetail accountPayableAdjustmentsDetail)
        {
            throw new NotImplementedException();
        }
    }

}
