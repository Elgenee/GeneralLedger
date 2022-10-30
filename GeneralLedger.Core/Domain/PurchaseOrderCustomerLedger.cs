namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderCustomerLedger")]
    public partial class PurchaseOrderCustomerLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderCustomerLedger()
        {
            PurchaseOrderCustomerLedgerDetails = new HashSet<PurchaseOrderCustomerLedgerDetail>();
        }

        public int ID { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        [Column(TypeName = "money")]
        public decimal? curSubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal? curGrandTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalPaidPendingPayments { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalDiscountsPendingDiscounts { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalChangePendingChange { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalBalance { get; set; }

        public DateTime? datDateInserted { get; set; }

        public bool? bitIsActive { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderCustomerLedgerDetail> PurchaseOrderCustomerLedgerDetails { get; set; }
    }
}
