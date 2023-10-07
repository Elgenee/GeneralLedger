using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;


namespace GeneralLedger.Persistence.Services
{
    public class SaleDetailServices : ISaleDetailServices
    {
        public SalesDetail Add(SalesDetail salesDetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetSalesDetailProductBySalesId(int Id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.SaleDetail.GetSalesDetailProductBySalesId(Id);
            }
        }

        public List<SalesDetail> GetSalesDetails()
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesDetail salesDetail)
        {
            throw new NotImplementedException();
        }

        public SalesDetail Update(SalesDetail salesDetail)
        {
            throw new NotImplementedException();
        }
    }
}
