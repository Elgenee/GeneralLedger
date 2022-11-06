using GeneralLedger.Core.Repositories;
using GeneralLedger.Core.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Persistence.Repositories
{
    public class JournalEntryRepository : Repository<tblJournalEntry> , IJournalEntryRepository
    {
       
        public JournalEntryRepository(GeneralLedgerContext context) : base(context)
        {

        }

        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<tblJournalEntry> GetJournalEntryWithGeneralLedger(int Id)
        {
            //GeneralLedgerContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //return GeneralLedgerContext.tblJournalEntries
            //    .Include(j => j.tblJournalEntry1)
            //    .Include(j => j.tblGLTranHeader.Select(h => h.tblGLTranDetails))
            //    .Include(j => j.tblGLTranHeader.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOA)))
            //    .Include(j => j.tblGLTranHeader.Select(h => h.tblGLTranDetails.Select(d => d.tblMasCOASub)))
            //    .Where(j => j.ID == Id)
            //    .ToList();

            return GeneralLedgerContext.tblJournalEntries.ToList();
        }
    }
}
