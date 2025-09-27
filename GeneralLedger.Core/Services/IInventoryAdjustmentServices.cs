using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Domain;
using GeneralLedger.Core.Repositories;

namespace GeneralLedger.Core.Services
{
    public interface IInventoryAdjustmentServices
    {

        InventoryAdjustment Add(InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<InventoryAdjustmentDetail> inventoryAdjustmentDetail);
        InventoryAdjustment Update(InventoryAdjustment inventoryAdjustment, List<tblGLTranDetail> tblGLTranDetail, bool UseDefaultEntry, List<InventoryAdjustmentDetail> inventoryAdjustmentDetail);
        void Remove(InventoryAdjustment inventoryAdjustment, List<InventoryAdjustmentDetail> inventoryAdjustmentDetail);
        List<InventoryAdjustment> GetAll();
        List<InventoryAdjustment> GetInventoryAdjustmentWithJournalEntry(int Id);

        List<InventoryAdjustment> GetInventoryAdjustmentWithInventoryAdjustmentType(string criteria);

    }
}
