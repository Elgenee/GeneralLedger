using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface IAccountsPayableAdjustmentsRepository : IRepository<AccountPayableAdjustment>
    {
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithJournalEntry(int Id);
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPaymentPurchases(string criteria, int intIdAccountsPayableAdjustmentsType);
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPurchases(string criteria, int intIdAccountsPayableAdjustmentsType);
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithSupplier(string criteria, int intIdAccountsPayableAdjustmentsType);
        IEnumerable<AccountPayableAdjustment> GetAccountPayableAdjustmentsDMCM(string criteria);

    }
}
