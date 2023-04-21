using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Tier.BO
{
    public class rptGetSupplierLedgerOverall
    {
        public int Id { get; set; }
        public int intIdPurchaseSupplierLedgerTransactionType { get; set; }
        public string strType { get; set; }
        public string strTransactionNo { get; set; }
        public string datDateTransaction { get; set; }
        public decimal curTotalAmountDebit { get; set; }
        public decimal curTotalAmountCredit { get; set; }
        public decimal curRunningBalance { get; set; }
    }
}
