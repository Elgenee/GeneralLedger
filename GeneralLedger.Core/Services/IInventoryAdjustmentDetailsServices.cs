using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;

namespace GeneralLedger.Core.Services
{
    public interface IInventoryAdjustmentDetailsServices
    {

        InventoryAdjustmentDetail Add(InventoryAdjustmentDetail inventoryAdjustmentDetail);

        InventoryAdjustmentDetail Update(InventoryAdjustmentType inventoryAdjustmentDetail);

        void Remove(InventoryAdjustmentDetail inventoryAdjustmentDetail);

        List<InventoryAdjustmentDetail> GetInventoryAdjustmentDetail();

        List<InventoryAdjustment> GetInventoryAdjustmentDetailById(int id);
    }
}
