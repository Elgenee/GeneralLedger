namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryLogOperationType")]
    public partial class InventoryLogOperationType
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string strName { get; set; }
    }
}
