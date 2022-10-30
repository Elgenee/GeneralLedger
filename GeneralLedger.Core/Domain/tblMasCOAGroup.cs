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
        public int ID { get; set; }

        [StringLength(50)]
        public string strCode { get; set; }

        [StringLength(200)]
        public string strName { get; set; }
    }
}
