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
        AccountReceivableAdjustment AddReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountReceivableAdjustment UpdateReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void RemoveReturnCheck(AccountReceivableAdjustment accountReceivableAdjustment);
        AccountReceivableAdjustment AddReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountReceivableAdjustment UpdateReturnSales(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void RemoveReturnSales(AccountReceivableAdjustment accountReceivableAdjustment);

        AccountReceivableAdjustment AddDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountReceivableAdjustment UpdateDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void RemoveDebitCreditMemo(AccountReceivableAdjustment accountReceivableAdjustment);
        List<AccountReceivableAdjustment> GetAll();
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithJournalEntry(int Id);
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCollectionSales(string criteria, int intIdAccountsReceivableAdjustmentsType);
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithSales(string criteria, int intIdAccountsReceivableAdjustmentsType);
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsWithCustomer(string criteria, int intIdAccountsReceivableAdjustmentsType);
        List<AccountReceivableAdjustment> GetAccountReceivableAdjustmentsDMCM(string criteria);
    }
}
