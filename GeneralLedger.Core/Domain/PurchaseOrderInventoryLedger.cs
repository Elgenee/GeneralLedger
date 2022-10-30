namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderInventoryLedger")]
    public partial class PurchaseOrderInventoryLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderInventoryLedger()
        {
            PurchaseOrderDetailInventoryLedgers = new HashSet<PurchaseOrderDetailInventoryLedger>();
        }

        public int Id { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datDateInserted { get; set; }

        public int? curTotalQty { get; set; }

        public int? curTotalReceived { get; set; }

        public int? curTotalRemaining { get; set; }

        public int? intIDReceivingStatus { get; set; }

        public virtual PuchaseOrderReceivingStatu PuchaseOrderReceivingStatu { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetailInventoryLedger> PurchaseOrderDetailInventoryLedgers { get; set; }
    }
}
