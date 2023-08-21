using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;
namespace GeneralLedger.Persistence.Services
{
    public class PurchaseDetailServices : IPurchaseDetailServices
    {
        public PurchaseDetail Add(PurchaseDetail purchaseDetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetPurchaseDetailProductByPurchaseId(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.PurchaseDetail.GetPurchaseDetailProductByPurchaseId(Id);
            }
        }

        public List<PurchaseDetail> GetPurchaseDetails()
        {
            throw new NotImplementedException();
        }

        public void Remove(PurchaseDetail purchaseDetail)
        {
            throw new NotImplementedException();
        }

        public PurchaseDetail Update(PurchaseDetail purchaseDetail)
        {
            throw new NotImplementedException();
        }
    }
}
