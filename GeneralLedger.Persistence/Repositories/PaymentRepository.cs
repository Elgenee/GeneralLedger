using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {

        public PaymentRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<Payment> GetPaymentWithJournalEntry(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Payment> GetPaymentWithPurchaseBank(string criteria)
        {
            return GeneralLedgerContext.Payments
                .Include(p => p.Purchase)
                .Include(p => p.Purchase.Supplier)
                .Include(p => p.Bank)
                .Include(p => p.tblGLTranHeaders)
                .Where(p => p.PaymentCV.ToLower().Contains(criteria.ToLower())
                || p.PaymentSIDR.ToLower().Contains(criteria.ToLower())
                || p.Purchase.Supplier.strName.ToLower().Contains(criteria.ToLower())
                || p.Purchase.PONo.ToLower().Contains(criteria.ToLower()))
                .ToList().Take(100);    
                
        }
    }
}
