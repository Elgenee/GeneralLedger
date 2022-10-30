namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderDetail")]
    public partial class PurchaseOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderDetail()
        {
            PurchaseOrderDetailInventoryLedgers = new HashSet<PurchaseOrderDetailInventoryLedger>();
            PurchaseOrderProductDetailHistories = new HashSet<PurchaseOrderProductDetailHistory>();
            PurchaseOrderReceivingDetails = new HashSet<PurchaseOrderReceivingDetail>();
        }

        public int Id { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        public int? intIDProduct { get; set; }

        public int? intIDProductDetail { get; set; }

        public int? curStock { get; set; }

        public int? curActStock { get; set; }

        public int? intQuantity { get; set; }

        public int? intQuantityReceived { get; set; }

        public int? intQuantityRemaining { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? curSubTotal { get; set; }

        public int? intIDReceivingStatus { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

        public virtual PuchaseOrderReceivingStatu PuchaseOrderReceivingStatu { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetailInventoryLedger> PurchaseOrderDetailInventoryLedgers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderProductDetailHistory> PurchaseOrderProductDetailHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderReceivingDetail> PurchaseOrderReceivingDetails { get; set; }
    }
}
