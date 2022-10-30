namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrder")]
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderCustomerLedgers = new HashSet<PurchaseOrderCustomerLedger>();
            PurchaseOrderInventoryLedgers = new HashSet<PurchaseOrderInventoryLedger>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            PurchaseOrderPayments = new HashSet<PurchaseOrderPayment>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strPONumber { get; set; }

        public int? intIDSupplier { get; set; }

        public int? intIDLocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datDatePurchased { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? curSubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDiscountPercentage { get; set; }

        [Column(TypeName = "money")]
        public decimal? curGrandTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalPaid { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalReceived { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalRemaining { get; set; }

        public bool? blnHasPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? curAmountPaid { get; set; }

        [Column(TypeName = "money")]
        public decimal? curChange { get; set; }

        public bool? blnApproved { get; set; }

        public int? intIDApprover { get; set; }

        public DateTime? datDateApproved { get; set; }

        public bool? blnAddBalanceToSupplier { get; set; }

        public DateTime? datDateInserted { get; set; }

        public int? intIDCreatedBy { get; set; }

        public int? intIDReceivingStatus { get; set; }

        public virtual PuchaseOrderReceivingStatu PuchaseOrderReceivingStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderCustomerLedger> PurchaseOrderCustomerLedgers { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderInventoryLedger> PurchaseOrderInventoryLedgers { get; set; }

        public virtual tblLocation tblLocation { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }
    }
}
