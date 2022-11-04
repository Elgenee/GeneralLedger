namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGLBookType")]
    public partial class tblGLBookType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGLBookType()
        {
            tblGLTranHeaders = new HashSet<tblGLTranHeader>();
        }

        public int ID { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGLTranHeader> tblGLTranHeaders { get; set; }
    }
}
