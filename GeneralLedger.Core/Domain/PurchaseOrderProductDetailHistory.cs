namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderProductDetailHistory")]
    public partial class PurchaseOrderProductDetailHistory
    {
        public int Id { get; set; }

        public int? intIDPurchaseOrderDetail { get; set; }

        public int? intIDPurchaseOrderProductTransactionType { get; set; }

        [StringLength(500)]
        public string strTransactionType { get; set; }

        public int? intQuantity { get; set; }

        public int? intTotalReceived { get; set; }

        public int? intTotalReturn { get; set; }

        public int? intTotalRemaining { get; set; }

        public DateTime? datDateInserted { get; set; }

        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }

        public virtual PurchaseOrderProductTransactionType PurchaseOrderProductTransactionType { get; set; }
    }
}
