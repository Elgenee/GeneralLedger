using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IPaymentServices
    {
        Payment Add(Payment payment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        Payment Update(Payment payment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry);
        void Remove(Payment payment);
        List<Payment> GetAll();
        List<Payment> GetPaymentWithJournalEntry(int Id);
        List<Payment> GetPaymentWithPurchaseBank(string criteria);



    }
}
