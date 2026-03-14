using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralLedger.Persistence.Services
{
    public class InventoryAdjustmentDetailServices : IInventoryAdjustmentDetailsServices
    {



        // Implement other methods (GetAll, Update, Remove, etc.) as needed, following the same mapping logic.
        public InventoryAdjustmentDetail Add(InventoryAdjustmentDetail inventoryAdjustmentDetail)
        {
            throw new NotImplementedException();
        }

        public List<InventoryAdjustmentDetail> GetInventoryAdjustmentDetail()
        {
            throw new NotImplementedException();
        }

        public List<InventoryAdjustment> GetInventoryAdjustmentDetailById(int id)
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.InventoryAdjustmentDetails.GetInventoryAdjustmentDetailInventoryAdjustmentId(id);
            }
        }

        public void Remove(InventoryAdjustmentDetail inventoryAdjustmentDetail)
        {
            throw new NotImplementedException();
        }

        public InventoryAdjustmentDetail Update(InventoryAdjustmentType inventoryAdjustmentDetail)
        {
            throw new NotImplementedException();
        }
    }
}