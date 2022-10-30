namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMasCOA")]
    public partial class tblMasCOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMasCOA()
        {
            tblMasCOASubs = new HashSet<tblMasCOASub>();
        }

        public int ID { get; set; }

        public int? intIDMasCOAGroup { get; set; }

        [StringLength(50)]
        public string strCode { get; set; }

        [StringLength(200)]
        public string strName { get; set; }

        [StringLength(10)]
        public string strAcctSide { get; set; }

        [StringLength(10)]
        public string strAcctType { get; set; }

        public int? intIncomeStatementOrderby { get; set; }

        public tblMasCOAGroup tblMasCOAGroup { get; set; }

        public ICollection<tblGLTranDetail> tblGLTranDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMasCOASub> tblMasCOASubs { get; set; }
    }
}
