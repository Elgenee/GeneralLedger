using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IGLTranServices
    {
        List<tblGLTranHeader> GetGLEntryById(int Id);

        List<tblGLTranHeader> GetGLEntryByPurchaseId(int PurchaseId);
    }
}
