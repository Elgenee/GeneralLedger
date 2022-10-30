namespace GeneralLedger.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string strProductName { get; set; }

        [StringLength(500)]
        public string strDescription { get; set; }

        public int? intIDProductCategory { get; set; }

        public int? intIDProductType { get; set; }

        public int? intIDProductBrands { get; set; }

        public int? intDefaultMinimum { get; set; }

        public int? intPerPiecePerBox { get; set; }

        public int? intIDLocation { get; set; }

        public int? intDefaultLength { get; set; }

        public int? intDefaultWidth { get; set; }

        public int? intDefaultHeight { get; set; }

        public int? intDefaultCargoCost { get; set; }

        public int? intTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDefaultCost { get; set; }

        public int? intIDPriceType { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDefaultRetail { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDefaultWholesale { get; set; }

        [Column(TypeName = "money")]
        public decimal? curDefaultMarkup { get; set; }

        public int? intIDProductCharacteristic { get; set; }

        public virtual PriceType PriceType { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ProductCharacteristic ProductCharacteristic { get; set; }

        public virtual ProductType ProductType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
