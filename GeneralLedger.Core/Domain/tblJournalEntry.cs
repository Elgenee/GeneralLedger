namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblJournalEntry")]
    public partial class tblJournalEntry
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string strTransactionNumber { get; set; }

        public DateTime? datBatchDate { get; set; }

        [StringLength(500)]
        public string strDescription { get; set; }

        [StringLength(50)]
        public string strTransactionCode { get; set; }
    }
}
