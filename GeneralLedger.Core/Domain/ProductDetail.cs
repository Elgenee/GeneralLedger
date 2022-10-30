namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDetail()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int Id { get; set; }

        public int? intIDProduct { get; set; }

        public int? intIDProductColor { get; set; }

        public int? intIDProductSize { get; set; }

        public int? intMininum { get; set; }

        public int? intLength { get; set; }

        public int? intWidth { get; set; }

        public int? intHeight { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCargoCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? curCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? curRetail { get; set; }

        [Column(TypeName = "money")]
        public decimal? curWholesale { get; set; }

        [Column(TypeName = "money")]
        public decimal? curMarkUp { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductColor ProductColor { get; set; }

        public virtual ProductDetail ProductDetail1 { get; set; }

        public virtual ProductDetail ProductDetail2 { get; set; }

        public virtual ProductSize ProductSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
