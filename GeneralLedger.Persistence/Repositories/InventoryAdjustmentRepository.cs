using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralLedger.Persistence.Repositories
{
    public class InventoryAdjustmentRepository : Repository<InventoryAdjustment>, IInventoryAdjustment
    {
        public InventoryAdjustmentRepository(GeneralLedgerContext context) : base(context)
        {
        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public IEnumerable<InventoryAdjustment> GetInventoryAdjustmentWithInventoryAdjustmentType(string criteria)
        {
            return GeneralLedgerContext.InventoryAdjustments
                .Include(i => i.InventoryAdjustmentType)
                .AsQueryable()
                .Where(i => i.TransactionNo.ToLower().Contains(criteria.ToLower())
                || i.InventoryAdjustmentType.Name.ToLower().Contains(criteria.ToLower()))
                .Take(100).ToList();

        }
    }
}
