using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Services;
using GeneralLedger.Persistence;

namespace GeneralLedger.Persistence.Services
{
    public class InventoryAdjustmentTypeServices : IInventoryAdjustmentTypeServices
    {
        public InventoryAdjustmentType Add(InventoryAdjustmentType inventoryAdjustmentType)
        {
            throw new NotImplementedException();
        }

        public List<InventoryAdjustmentType> GetInventoryAdjustmentType()
        {
            using (var unitOfWork = new UnitOfWork(new GeneralLedgerContext()))
            {
                return unitOfWork.InventoryAdjustmentType.GetAll().ToList();
            }
        }

        public InventoryAdjustmentType GetInventoryAdjustmentTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(InventoryAdjustmentType inventoryAdjustmentType)
        {
            throw new NotImplementedException();
        }

        public InventoryAdjustmentType Update(InventoryAdjustmentType inventoryAdjustmentType)
        {
            throw new NotImplementedException();
        }
    }
}
