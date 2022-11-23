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
    public class SalesCustomerLedgerServices : ISalesCustomerLedgerServices
    {
        public IEnumerable<spGetSalesCustomerLedger_Result> GetSalesCustomerLedger(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.SalesCustomerLedger.GetSalesCustomerLedger(Id);
            }
        }
    }
}
