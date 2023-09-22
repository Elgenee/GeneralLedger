using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IPurchaseServices
    {
        Purchase Add(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> PurchaseDetailsList);
        Purchase Update(Purchase purchase, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<PurchaseDetail> PurchaseDetailsList);
        void Remove(Purchase purchase, List<PurchaseDetail> PurchaseDetailsList);
        List<Purchase> GetAll();
        List<Purchase> GetPurchasesWithJournalEntry(int Id);
        List<Purchase> GetPurchaseWithSupplier(string criteria);

        List<Purchase> GetPurchaseWithoutReturnPurchase(string criteria);

        Purchase GetPurchase(int Id);
        Purchase GetPurchaseWithSupplier(int Id);




    }
}
