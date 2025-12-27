using GeneralLedger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Core.Services
{
    public  interface IPurchaseSupplierLedgerServices
    {
        IEnumerable<spGetPurchaseSupplierLedger_Result> GetPurchaseSupplierLedger(int Id);
    }
}
