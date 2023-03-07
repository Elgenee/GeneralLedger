using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface ItblTBBatchHdrServices
    {
        bool Lock(int TBHdrID);
        bool Unlock(int TBHdrID);
        bool CheckIfLock(DateTime dateInput);
    }
}
