using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Core.Services
{
    public interface ISaleDetailServices
    {


        SalesDetail Add(SalesDetail salesDetail);

        SalesDetail Update(SalesDetail salesDetail);

        void Remove(SalesDetail salesDetail);

        List<SalesDetail> GetSalesDetails();

        IEnumerable<Sale> GetSalesDetailProductBySalesId(int Id);
    }
}
