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

        public List<tblGLTranHeader> GetGLEntryByPurchaseId(int PurchaseId)
        {

            return GeneralLedgerContext.tblGLTranHeaders
             .Include(j => j.tblGLTranDetails)
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOA))
             .Include(j => j.tblGLTranDetails.Select(d => d.tblMasCOASub))
             .Where(j => j.intIdPurchase == PurchaseId)
             .ToList();

        }
    }
}
