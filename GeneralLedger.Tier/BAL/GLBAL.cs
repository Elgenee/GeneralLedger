using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Utility;
using GeneralLedger.Tier.DAL;
using GeneralLedger.Tier.BO;

namespace GeneralLedger.Tier.BAL
{
    public class GLBAL
    {
        public List<rptISIncome> getRepISIncome(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISIncome(intFiscalYear, intMonth);

        }

        public List<rptISLessSales> getRepISLessSales(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISLessSales(intFiscalYear, intMonth);

        }

        public List<rptISLessCostOfGoodSold> getRepISLessCostOfGoodSold(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISLessCostOfGoodSold(intFiscalYear, intMonth);


        }


        public List<rptJournalProoflist> getJournalEntryProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getJournalEntryProoflist(datDateFrom, datDateTo);

        }

        public List<rptJournalProoflist> getSalesEntryProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getSalesEntryProoflist(datDateFrom, datDateTo);

        }


        public List<rptPurchaseProoflist> getPurchaseProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getPurchaseProoflist(datDateFrom, datDateTo);

        }

        public List<rptInventoryProoflist> getInventoryProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getInventoryProoflist(datDateFrom, datDateTo);

        }

        public List<rptInventoryMonthlyOutstandingSummary> getInventoryMonthlyOutstandingSummary(DateTime monthDate)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getInventoryMonthlyOutstandingSummary(monthDate);
        }

        public List<rptJournalProoflist> getCollectionEntryProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getCollectionEntryProoflist(datDateFrom, datDateTo);

        }


        public List<rptPaymentProoflist> getPaymentProoflist(string datDateFrom, string datDateTo)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getPaymentProoflist(datDateFrom, datDateTo);

        }

        public List<rptGetSummaryOfAccountsReceivablesSales> getSummaryOfAccountsReceivablesSales(string datDateAsOf)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getSummaryOfAccountsReceivablesSales(datDateAsOf);

        }

        public List<rptGetCustomerLedgerOverall> getCustomerLedgerOverall(int customerId)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getCustomerLedgerOverall(customerId);

        }

        public List<rptGetSupplierLedgerOverall> getSupplierLedgerOverall(int supplierId)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getSupplierLedgerOverall(supplierId);

        }

        public List<rptBSCashBank> getBSCashBank(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepBSCashBank(intFiscalYear, intMonth);

        }

        public List<rptBSCashBank> getRepBSFixedAsset(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepBSFixedAsset(intFiscalYear, intMonth);

        }

        public List<rptBSCashBank> getRepBSOtherAsset(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepBSOtherAsset(intFiscalYear, intMonth);

        }

        public List<rptBSCashBank> getRepBSLiabilityAccountsPayable(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepBSLiabilityAccountsPayable(intFiscalYear, intMonth);

        }

        public List<rptBSCashBank> getRepBSOwnersEquity(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepBSOwnersEquity(intFiscalYear, intMonth);

        }


        public List<rptFATransportationEquipment> getRepFATransportationEquipment(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepFATransportationEquipment(intFiscalYear, intMonth);
        }


        public List<rptOtherAsset> getRepOtherAsset(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepOtherAsset(intFiscalYear, intMonth);
        }

        public List<rptFALessACCUMDEPN> getRepFALessACCUMDEPN(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepFALessACCUMDEPN(intFiscalYear, intMonth);
        }

        public List<rptISExpenses> getRepISExpense(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISExpense(intFiscalYear, intMonth);

        }

        public List<rptISTotal> getRepISTotal(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISTotal(intFiscalYear, intMonth);

        }

        public List<rptISProvisionIT> getRepISProvIT(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISProvIT(intFiscalYear, intMonth);

        }

        public List<rptISNetIncome> getRepISNetInc(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISNetIncome(intFiscalYear, intMonth);


        }


        public List<rptISNetSalesTotal> getRepISNetSalesTotal(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISNetSalesTotal(intFiscalYear, intMonth);

        }
        //getRepISLessCostOfGoodSoldTotal


        public List<rptISNetSalesTotal> getRepISLessCostOfGoodSoldTotal(int intFiscalYear, int intMonth)
        {
            GLDAL gltb = new GLDAL();
            return gltb.getRepISLessCostOfGoodSoldTotal(intFiscalYear, intMonth);

        }
    }
}