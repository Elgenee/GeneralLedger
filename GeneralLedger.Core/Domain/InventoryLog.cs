namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryLog")]
    public partial class InventoryLog
    {
        public int Id { get; set; }

        public int? intProductDetailId { get; set; }

        public int? intQuantity { get; set; }

        public int? intInventoryLogOperationType { get; set; }

        public DateTime? datDateInserted { get; set; }

        public int? intQuantityBefore { get; set; }

        public int? intQuantityAfter { get; set; }

        public int? intIDReference { get; set; }
    }
}
