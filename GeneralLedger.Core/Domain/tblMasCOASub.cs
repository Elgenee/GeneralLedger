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
        public int ID { get; set; }

        public int? intIDMasCOA { get; set; }

        [StringLength(50)]
        public string strCode { get; set; }

        [StringLength(50)]
        public string strName { get; set; }

        public virtual tblMasCOA tblMasCOA { get; set; }

        public ICollection<tblGLTranDetail> tblGLTranDetails { get; set; }
    }
}
