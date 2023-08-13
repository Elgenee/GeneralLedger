using GeneralLedger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Core.Services
{
    
    public interface IProductServices
    {

        Product Add(Product product);

        Product Update(Product product);

        void Remove(Product product);

        List<Product> GetProduct();


    }
}
