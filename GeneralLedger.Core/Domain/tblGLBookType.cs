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
        public int ID { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        //[StringLength(10)]
        //public string sampleColumn { get; set; }

        //public int? sampleCOlumn1 { get; set; }

        //public int? sampleColumn2 { get; set; }

        //public int? sampleColumn3 { get; set; }
        public List<tblGLTranHeader> tblGLTranHeaders { get; set; }
    }
}
