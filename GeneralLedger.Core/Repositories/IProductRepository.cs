using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Repositories
{
    //create a product repository interface
    public interface IProductRepository : IRepository<Product>
    {
        //add additional methods here
        //for example
        //Product GetProductWithCategory(int id);
    }
 
}
