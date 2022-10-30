using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Tier.BO;
using GeneralLedger.Tier.DAL;
using GeneralLedger.Utility;

namespace GeneralLedger.Tier.BAL
{
    public class TrialBalanceBAL
    {
        public List<GLTBHdr> getGLTB(DateTime xFrom, DateTime xTo)
        {
            TrialBalanceDAL gltb = new TrialBalanceDAL();
            return gltb.getGLTB(xFrom, xTo);
        }

        public List<GLTBHdr> getGLTBById(int Id)
        {
            TrialBalanceDAL gltb = new TrialBalanceDAL();
            return gltb.getGLTBById(Id);
        }

        public List<GLTBDtl> getGLTBDetail(int Id)
        {
            TrialBalanceDAL gltb = new TrialBalanceDAL();
            return gltb.getGLTBDetail(Id);
        }

        public string PostGL(string dtBatch, string xRemerks)
        {
            TrialBalanceDAL gltb = new TrialBalanceDAL();

            return gltb.PostGL(dtBatch, xRemerks);

        }

    }
}
