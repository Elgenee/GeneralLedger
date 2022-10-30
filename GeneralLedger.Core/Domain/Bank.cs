namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bank")]
    public partial class Bank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bank()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        [StringLength(50)]
        public string strAccountNo { get; set; }

        [StringLength(500)]
        public string strAccountName { get; set; }

        [StringLength(500)]
        public string strBranch { get; set; }

        [Column(TypeName = "money")]
        public decimal? curStartingDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCredit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curBalance { get; set; }

        public int? intIDCurrency { get; set; }

        public virtual Currency Currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
