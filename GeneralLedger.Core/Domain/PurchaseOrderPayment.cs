namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderPayment")]
    public partial class PurchaseOrderPayment
    {
        public int Id { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datPaidOn { get; set; }

        [StringLength(500)]
        public string datPaidBy { get; set; }

        [Column(TypeName = "money")]
        public decimal? curTotalAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal? curGrandTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curAmountPaid { get; set; }

        public int? intIDPurchaseOrderPaymentStatus { get; set; }

        [StringLength(50)]
        public string strBankAccounts { get; set; }

        [Column(TypeName = "date")]
        public DateTime? curDatCheckDate { get; set; }

        [StringLength(50)]
        public string strCheckNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datApprovedOn { get; set; }

        [StringLength(500)]
        public string datApprovedBy { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
