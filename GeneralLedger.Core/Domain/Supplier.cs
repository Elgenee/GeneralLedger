namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        public int? intIDCurrency { get; set; }

        [Column(TypeName = "money")]
        public decimal? curStartingDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCredit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curBalance { get; set; }

        [StringLength(500)]
        public string strAddress { get; set; }

        [StringLength(500)]
        public string strContacts { get; set; }

        public int? intIDBank { get; set; }

        public virtual Bank Bank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
