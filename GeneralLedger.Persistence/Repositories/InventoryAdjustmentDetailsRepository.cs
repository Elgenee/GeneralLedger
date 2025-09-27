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
    public class InventoryAdjustmentDetailsRepository : Repository<InventoryAdjustmentDetail>, IInventoryAdjustmentDetails
    {
        public InventoryAdjustmentDetailsRepository(GeneralLedgerContext context) : base(context)
        {

        }
        public GeneralLedgerContext GeneralLedgerContext
        {
            get { return Context as GeneralLedgerContext; }
        }

        public List<InventoryAdjustment> GetInventoryAdjustmentDetailInventoryAdjustmentId(int Id)
        {
            return GeneralLedgerContext.InventoryAdjustments
                .Include(i => i.InventoryAdjustmentDetails)
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductCharacteristic))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductCategory))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductType))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductBrand))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductColor))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductSize))
                .Include(i => i.InventoryAdjustmentDetails.Select(pd => pd.Product.ProductUnit))
                .Where(i => i.Id == Id)
                .ToList();

        }
    }
}
