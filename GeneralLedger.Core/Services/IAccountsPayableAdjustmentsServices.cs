using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IAccountsPayableAdjustmentsServices
    {

        AccountPayableAdjustment AddReturnPayment(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountPayableAdjustment UpdateReturnPayment(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void RemoveReturnPayment(AccountPayableAdjustment accountPayableAdjustment );
        AccountPayableAdjustment AddReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetailsList);
        AccountPayableAdjustment UpdateReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetailsList);

        void RemoveReturnPurchases(AccountPayableAdjustment accountPayableAdjustment, List<AccountPayableAdjustmentsDetail> accountPayableAdjustmentsDetailsList);

        AccountPayableAdjustment AddDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        AccountPayableAdjustment UpdateDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void RemoveDebitCreditMemo(AccountPayableAdjustment accountPayableAdjustment);
        List<AccountPayableAdjustment> GetAll();
        List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithJournalEntry(int Id);
        List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPaymentPurchases(string criteria, int intIdAccountsPayableAdjustmentsType);
        List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithPurchases(string criteria, int intIdAccountsPayableAdjustmentsType);
        List<AccountPayableAdjustment> GetAccountPayableAdjustmentsWithSupplier(string criteria, int intIdAccountsPayableAdjustmentsType);
        List<AccountPayableAdjustment> GetAccountPayableAdjustmentsDMCM(string criteria);

    }
}
