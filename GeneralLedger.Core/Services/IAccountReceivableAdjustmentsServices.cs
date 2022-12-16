using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IAccountReceivableAdjustmentsServices
    {
        AccountReceivableAdjustment Add(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountReceivableAdjustment Update(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void Remove(AccountReceivableAdjustment accountReceivableAdjustment);
        List<AccountReceivableAdjustment> GetAll();
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id);
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria);
    }
}
