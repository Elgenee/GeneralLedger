using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;


namespace GeneralLedger.Persistence.Services
{
    public class GLTranServices : IGLTranServices
    {
        public List<tblGLTranHeader> GetGLEntryByAdjustmentReturnPurchaseId(int ReturnPurchaseId, int BookTypeId)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.GLTran.GetGLEntryByAdjustmentReturnPurchaseId(ReturnPurchaseId, BookTypeId).ToList();
            }
        }

        public List<tblGLTranHeader> GetGLEntryByAdjustmentReturnSaleId(int ReturnSaleId, int BookTypeId)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.GLTran.GetGLEntryByAdjustmentReturnSaleId(ReturnSaleId, BookTypeId).ToList();
            }
        }

        public List<tblGLTranHeader> GetGLEntryById(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.GLTran.GetGLEntryById(Id).ToList();
            }
        }

        public List<tblGLTranHeader> GetGLEntryByPurchaseId(int PurchaseId, int BookTypeId)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.GLTran.GetGLEntryByPurchaseId(PurchaseId , BookTypeId).ToList();

            }
        }

        public List<tblGLTranHeader> GetGLEntryBySalesId(int SalesId, int BookTypeId)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.GLTran.GetGLEntryBySalesId(SalesId, BookTypeId).ToList();

            }
        }
    }
}
