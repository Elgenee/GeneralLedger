namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMasCOASub")]
    public partial class tblMasCOASub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasCOASub()
        {
            tblGLTranDetails = new HashSet<tblGLTranDetail>();
        }

        public int ID { get; set; }

        public int? intIDMasCOA { get; set; }

        [StringLength(50)]
        public string strCode { get; set; }

        [StringLength(50)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGLTranDetail> tblGLTranDetails { get; set; }

        public virtual tblMasCOA tblMasCOA { get; set; }
    }
}
