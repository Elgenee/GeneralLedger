namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMasCOAGroup")]
    public partial class tblMasCOAGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasCOAGroup()
        {
            tblMasCOAs = new HashSet<tblMasCOA>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string strCode { get; set; }

        [StringLength(200)]
        public string strName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMasCOA> tblMasCOAs { get; set; }
    }
}
