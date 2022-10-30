namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderCustomerLedgerDetail")]
    public partial class PurchaseOrderCustomerLedgerDetail
    {
        public int ID { get; set; }

        public int? intIDPurchaseOrderCustomerLedger { get; set; }

        public int? intIDPaymentType { get; set; }

        [StringLength(50)]
        public string strReference { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? curAmountPaid { get; set; }

        [Column(TypeName = "money")]
        public decimal? curChange { get; set; }

        public virtual PurchaseOrderCustomerLedger PurchaseOrderCustomerLedger { get; set; }
    }
}
