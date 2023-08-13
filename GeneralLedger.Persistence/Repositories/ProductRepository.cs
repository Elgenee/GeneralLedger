using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository 
    { 
    
        //fix this
        public ProductRepository(GeneralLedgerContext context) : base(context)
        {

        }
        //fix this
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }
        //fix this
 
    
    }
   
}
