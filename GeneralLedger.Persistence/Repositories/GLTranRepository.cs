using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class GLTranRepository : Repository<tblGLTranHeader>, IGLTranRepository
    {

        public GLTranRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public List<tblGLTranHeader> GetGLEntryByAdjustmentReturnPurchaseId(int ReturnPurchaseId, int BookTypeId)
        {
            return GeneralLedgerContext.tblGLTranHeaders
                    .Include(j => j.tblGLTranDetails)
                    .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
                    .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
                    .Where(j => j.intIdAccountPayableAdjustment == ReturnPurchaseId && j.intIDGLBookType == BookTypeId)
                    .ToList();
        }

        public List<tblGLTranHeader> GetGLEntryByAdjustmentReturnSaleId(int ReturnSaleId, int BookTypeId)
        {
            return GeneralLedgerContext.tblGLTranHeaders
                    .Include(j => j.tblGLTranDetails)
                    .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
                    .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
                    .Where(j => j.intIdAccountReceivableAdjustment == ReturnSaleId && j.intIDGLBookType == BookTypeId)
                    .ToList();
        }

        public IEnumerable<tblGLTranHeader> GetGLEntryById(int Id)
        {
            return GeneralLedgerContext.tblGLTranHeaders
                .Include(j => j.tblGLTranDetails)
                .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
                .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
                .Where(j => j.ID == Id)
                .ToList();

            //throw new System.NotImplementedException();
        }

        public List<tblGLTranHeader> GetGLEntryByPurchaseId(int PurchaseId , int BookTypeId)
        {

            return GeneralLedgerContext.tblGLTranHeaders
             .Include(j => j.tblGLTranDetails)
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
             .Where(j => j.intIdPurchase == PurchaseId && j.intIDGLBookType == BookTypeId)
             .ToList();

        }

        public List<tblGLTranHeader> GetGLEntryBySalesId(int SalesId, int BookTypeId)
        {
            return GeneralLedgerContext.tblGLTranHeaders
             .Include(j => j.tblGLTranDetails)
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
             .Where(j => j.intIdSales == SalesId && j.intIDGLBookType == BookTypeId)
             .ToList();
        }
    }
}
