namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryStock")]
    public partial class InventoryStock
    {
        public int Id { get; set; }

        public int? intIDProduct { get; set; }

        public int? intIDProductDetail { get; set; }

        public int? intStockCount { get; set; }

        public int? blnIsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datLastModified { get; set; }
    }
}
