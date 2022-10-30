namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }

        [Column(TypeName = "money")]
        public decimal? curStartingDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDebit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCredit { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCreditLimit { get; set; }

        public int? intTerms { get; set; }

        public int? intIDPriceType { get; set; }

        [StringLength(500)]
        public string strAddress { get; set; }

        [StringLength(500)]
        public string strContact { get; set; }

        public virtual PriceType PriceType { get; set; }
    }
}
