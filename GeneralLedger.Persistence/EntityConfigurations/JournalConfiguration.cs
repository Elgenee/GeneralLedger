using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;


namespace GeneralLedger.Persistence.EntityConfigurations
{
    public class JournalConfiguration : EntityTypeConfiguration<tblJournalEntry>
    {

        public JournalConfiguration()
        {
            HasMany(j => j.tblGLTranHeader)
                .WithOptional(h => h.tblJournalEntry)
                .HasForeignKey(h => h.intIDReference);


        }
    }
}
