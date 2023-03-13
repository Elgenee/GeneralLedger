using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Repositories
{
    public interface IPurchaseSupplierLedgerRepository : IRepository<PurchaseSupplierLedger>
    {

        IEnumerable<spGetPurchaseSupplierLedger_Result> GetPurchaseSupplierLedger(int Id);
    }
}
