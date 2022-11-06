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
    public class SaleServices : ISaleServices
    {
        public Sale Add(Sale sale)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                unitOfWork.Sale.Add(sale);
                unitOfWork.Complete();
                return sale;
            }
        }

        public List<Sale> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.Sale.GetAll().ToList();
            }
        }

        public void Remove(Sale sale)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Sale.Get(sale.Id);
                unitOfWork.Sale.Remove(result);
                unitOfWork.Complete();
            }
        }

        public Sale Update(Sale sale)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                var result = unitOfWork.Sale.Get(sale.Id);
                result.PONo = sale.PONo;
                result.TRANo = sale.TRANo;
                result.Total = sale.Total;
                result.TransactionDate = sale.TransactionDate;
                result.intIdCustomer = sale.intIdCustomer;
                result.intIdAgent = sale.intIdAgent;
                unitOfWork.Complete();
                return sale;
            }
        }
    }
}
