using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    public interface IGLTranRepository : IRepository<tblGLTranHeader>
    {
        IEnumerable<tblGLTranHeader> GetGLEntryById(int Id);

        List<tblGLTranHeader> GetGLEntryByPurchaseId(int PurchaseId, int BookTypeId);

        List<tblGLTranHeader> GetGLEntryBySalesId(int SalesId, int BookTypeId);

        List<tblGLTranHeader> GetGLEntryByAdjustmentReturnPurchaseId(int ReturnPurchaseId, int BookTypeId);

        List<tblGLTranHeader> GetGLEntryByAdjustmentReturnSaleId(int ReturnSaleId, int BookTypeId);

    }
}
