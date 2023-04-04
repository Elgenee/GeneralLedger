using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Repositories
{
    public interface IAccountReceivableAdjustmentsRepository : IRepository<AccountReceivableAdjustment>
    {
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id);
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria, int intIdAccountsReceivableAdjustmentsType);
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithSales(string criteria, int intIdAccountsReceivableAdjustmentsType);
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCustomer(string criteria, int intIdAccountsReceivableAdjustmentsType);
        IEnumerable<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDMCM(string criteria);
    }
}
