namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrderReceivingDetail
    {
        public int Id { get; set; }

        public int? intIDPurchaseOrderReceiving { get; set; }

        public int? intIDPurchaseOrderDetail { get; set; }

        public int? intQuantity { get; set; }

        public int? intQuantityReceived { get; set; }

        public int? intQuantityRemaining { get; set; }

        public int? intAddedQuantityReceived { get; set; }

        public bool? blnIsReceived { get; set; }

        public DateTime? datDateInserted { get; set; }

        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }

        public virtual PurchaseOrderReceiving PurchaseOrderReceiving { get; set; }
    }
}
