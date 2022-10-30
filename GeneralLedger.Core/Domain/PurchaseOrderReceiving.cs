namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderReceiving")]
    public partial class PurchaseOrderReceiving
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderReceiving()
        {
            PurchaseOrderReceivingDetails = new HashSet<PurchaseOrderReceivingDetail>();
        }

        public int Id { get; set; }

        public int? intIDPurchaseOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datDateReceived { get; set; }

        public int? intIDLocation { get; set; }

        [StringLength(500)]
        public string strAddress { get; set; }

        [StringLength(500)]
        public string strMemo { get; set; }

        public DateTime? datDateInserted { get; set; }

        public bool? blnReceivedOnPO { get; set; }

        public int? curTotalQty { get; set; }

        public int? curTotalReceived { get; set; }

        public int? curTotalRemaining { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderReceivingDetail> PurchaseOrderReceivingDetails { get; set; }
    }
}
