using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;


namespace GeneralLedger.Persistence.Services
{
    public class tblTBBatchHdrServices : ItblTBBatchHdrServices
    {
        public bool CheckIfLock(DateTime dateInput)
        {
            var endOfTheMonth = GetEndOfTheMonth(dateInput);

            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var tblTb = unitOfWork.tblTBBatchHdr
                    .Find(t => t.datBatchDate == endOfTheMonth && (t.bitIsLock ?? false) == true)
                    .SingleOrDefault();

                return (tblTb == null) ? false : true;
            }

        }

        public DateTime GetEndOfTheMonth(DateTime dateInput)
        {
            var dayResult = DateTime.DaysInMonth(dateInput.Year, dateInput.Month);
            DateTime lastDateOfMonth = new DateTime(dateInput.Year, dateInput.Month, dayResult);
            return lastDateOfMonth;
        }

        public bool Lock(int TBHdrID)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var tblTb = unitOfWork.tblTBBatchHdr.Find(t => t.ID == TBHdrID).SingleOrDefault();
                tblTb.bitIsLock = true;
                unitOfWork.Complete();
                return true;
            }
        }

        public bool Unlock(int TBHdrID)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var tblTb = unitOfWork.tblTBBatchHdr.Find(t => t.ID == TBHdrID).SingleOrDefault();
                tblTb.bitIsLock = false;
                unitOfWork.Complete();
                return true;
            }
        }
    }
}
