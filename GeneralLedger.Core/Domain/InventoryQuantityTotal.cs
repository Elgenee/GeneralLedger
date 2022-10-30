namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryQuantityTotal")]
    public partial class InventoryQuantityTotal
    {
        public int Id { get; set; }

        public int? intProductId { get; set; }

        public int? intProductDetailId { get; set; }

        public int? intQuantityOnHand { get; set; }

        public int? intQuantityOnSold { get; set; }

        public int? intQuantityOnOrder { get; set; }
    }
}
