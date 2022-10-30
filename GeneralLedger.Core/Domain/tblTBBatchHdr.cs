namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTBBatchHdr")]
    public partial class tblTBBatchHdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTBBatchHdr()
        {
            tblTBBatchDtls = new HashSet<tblTBBatchDtl>();
        }

        public int ID { get; set; }

        public DateTime? datBatchDate { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTBBatchDtl> tblTBBatchDtls { get; set; }
    }
}
