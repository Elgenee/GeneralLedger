namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGLTranDetail")]
    public partial class tblGLTranDetail
    {
        public int ID { get; set; }

        public int intIDGLTranHeader { get; set; }

        public int intIDMasCoa { get; set; }

        public int intIDMasCoaSub { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCredit { get; set; }

        public virtual tblMasCOA tblMasCOA { get; set; }

        public virtual tblMasCOASub tblMasCOASub { get; set; }

        public virtual tblGLTranHeader tblGLTranHeader { get; set; }
    }
}
