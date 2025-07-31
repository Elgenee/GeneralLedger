using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        public CustomerRepository(GeneralLedgerContext context) : base(context)
        {
        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }
    }
}
