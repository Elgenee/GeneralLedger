namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderDetailInventoryLedger")]
    public partial class PurchaseOrderDetailInventoryLedger
    {
        public int Id { get; set; }

        public int? intIDPurchaseOrderInventoryLedger { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        public int? intIDPurchaseOrderDetail { get; set; }

        public int? curStock { get; set; }

        public int? curActStock { get; set; }

        public int? intQuantity { get; set; }

        public int? intQuantityReceived { get; set; }

        public int? intQuantityRemaining { get; set; }

        public int? intIDReceivingStatus { get; set; }

        public virtual PuchaseOrderReceivingStatu PuchaseOrderReceivingStatu { get; set; }

        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }

        public virtual PurchaseOrderInventoryLedger PurchaseOrderInventoryLedger { get; set; }
    }
}
