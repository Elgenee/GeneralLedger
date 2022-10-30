using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Persistence.EntityConfigurations
{
    public class SaleConfiguration : EntityTypeConfiguration<Sale>
    {
        public SaleConfiguration()
        {
            HasRequired(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.intIdCustomer);
        }
    }
}
