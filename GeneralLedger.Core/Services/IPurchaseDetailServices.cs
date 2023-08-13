using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IPurchaseDetailServices
    {
        PurchaseDetail Add(PurchaseDetail purchaseDetail);

        PurchaseDetail Update(PurchaseDetail purchaseDetail);

        void Remove(PurchaseDetail purchaseDetail);

        List<PurchaseDetail> GetPurchaseDetails();

    }
}
