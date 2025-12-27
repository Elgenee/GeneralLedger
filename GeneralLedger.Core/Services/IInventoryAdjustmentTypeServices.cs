using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IInventoryAdjustmentTypeServices
    {
        InventoryAdjustmentType Add(InventoryAdjustmentType inventoryAdjustmentType);

        InventoryAdjustmentType Update(InventoryAdjustmentType inventoryAdjustmentType);

        void Remove(InventoryAdjustmentType inventoryAdjustmentType);

        List<InventoryAdjustmentType> GetInventoryAdjustmentType();

        InventoryAdjustmentType GetInventoryAdjustmentTypeById(int id);

    }
}
