namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGLTranHeader")]
    public partial class tblGLTranHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGLTranHeader()
        {
            tblGLTranDetails = new HashSet<tblGLTranDetail>();
        }

        public int ID { get; set; }

        public int? intIDGLBookType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datBatchDate { get; set; }

        public int? intIDReference { get; set; }

        [StringLength(50)]
        public string strTransactionCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCreditAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDebitAmount { get; set; }

        public DateTime? datInsertedDate { get; set; }

        [StringLength(500)]
        public string strDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGLTranDetail> tblGLTranDetails { get; set; }

        public tblGLBookType tblGLBookType { get; set; }
    }
}
