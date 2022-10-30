namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderProductTransactionType")]
    public partial class PurchaseOrderProductTransactionType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderProductTransactionType()
        {
            PurchaseOrderProductDetailHistories = new HashSet<PurchaseOrderProductDetailHistory>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderProductDetailHistory> PurchaseOrderProductDetailHistories { get; set; }
    }
}
