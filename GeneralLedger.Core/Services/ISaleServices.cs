using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface ISaleServices
    {
        Sale Add(Sale sale);
        Sale Update(Sale sale);
        void Remove(Sale sale);
        List<Sale> GetAll();
        
    }

}
