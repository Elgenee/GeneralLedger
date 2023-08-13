using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface IStockServices
    {

        Stock Add(Stock stock);

        Stock Update(Stock agent);

        void Remove(Stock agent);

        List<Stock> GetStocks();
    }
}
