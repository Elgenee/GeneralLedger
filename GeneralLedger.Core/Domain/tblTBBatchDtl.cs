namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTBBatchDtl")]
    public partial class tblTBBatchDtl
    {
        public int ID { get; set; }

        public int intIDTBBatchHdr { get; set; }

        public int? COA { get; set; }

        [StringLength(50)]
        public string COADesc { get; set; }

        public int? COASub { get; set; }

        [StringLength(50)]
        public string COASubDesc { get; set; }

        public decimal? curBegBal { get; set; }

        public decimal? curDebit { get; set; }

        public decimal? curCredit { get; set; }

        public decimal? curEndBal { get; set; }

        public decimal? curAdjustedDebit { get; set; }

        public decimal? curAdjustedCredit { get; set; }

        public decimal? curEndBalAdjusted { get; set; }

        public virtual tblTBBatchHdr tblTBBatchHdr { get; set; }
    }
}
