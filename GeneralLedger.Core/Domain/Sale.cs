namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        public int Id { get; set; }
        public DateTime? TransactionDate { get; set; }
        [StringLength(500)]
        public string TRANo { get; set; }
        [StringLength(500)]
        public string PONo { get; set; }
        public int intIdCustomer { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
        public Customer Customer { get; set; }

    }
}
