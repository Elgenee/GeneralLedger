namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PuchaseOrderReceivingStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PuchaseOrderReceivingStatu()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            PurchaseOrderDetailInventoryLedgers = new HashSet<PurchaseOrderDetailInventoryLedger>();
            PurchaseOrderInventoryLedgers = new HashSet<PurchaseOrderInventoryLedger>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetailInventoryLedger> PurchaseOrderDetailInventoryLedgers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderInventoryLedger> PurchaseOrderInventoryLedgers { get; set; }
    }
}
