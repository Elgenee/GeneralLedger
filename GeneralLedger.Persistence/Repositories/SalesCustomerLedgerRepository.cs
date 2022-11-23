using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GeneralLedger.Persistence.Repositories
{
    public class SalesCustomerLedgerRepository : Repository<SalesCustomerLedger>, ISalesCustomerLedgerRepository
    {

        public SalesCustomerLedgerRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<spGetSalesCustomerLedger_Result> GetSalesCustomerLedger(int Id)
        {
            return GeneralLedgerContext.spGetSalesCustomerLedger(Id).ToList();
        }
    }
}
