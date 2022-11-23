using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface ICollectionServices
    {
        Collection Add(Collection collection);
        Collection Update(Collection collection, List<tblGLTranDetail> tblGLTranDetail);
        void Remove(Collection collection);
        List<Collection> GetAll();
        List<Collection> GetCollectionWithJournalEntry(int Id);
        List<Collection> GetCollectionWithSaleBank(string criteria);
    }
}
