using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GeneralLedger.Core.Domain
{
    public partial class GeneralLedgerContext : DbContext
    {
        public GeneralLedgerContext()
            : base("name=GeneralLedgerContext")
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InventoryLog> InventoryLogs { get; set; }
        public virtual DbSet<InventoryLogOperationType> InventoryLogOperationTypes { get; set; }
        public virtual DbSet<InventoryQuantityTotal> InventoryQuantityTotals { get; set; }
        public virtual DbSet<InventoryStock> InventoryStocks { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductUnit> ProductUnits { get; set; }
        public virtual DbSet<PuchaseOrderReceivingStatu> PuchaseOrderReceivingStatus { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderCustomerLedger> PurchaseOrderCustomerLedgers { get; set; }
        public virtual DbSet<PurchaseOrderCustomerLedgerDetail> PurchaseOrderCustomerLedgerDetails { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderDetailInventoryLedger> PurchaseOrderDetailInventoryLedgers { get; set; }
        public virtual DbSet<PurchaseOrderInventoryLedger> PurchaseOrderInventoryLedgers { get; set; }
        public virtual DbSet<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }
        public virtual DbSet<PurchaseOrderPaymentStatu> PurchaseOrderPaymentStatus { get; set; }
        public virtual DbSet<PurchaseOrderProductDetailHistory> PurchaseOrderProductDetailHistories { get; set; }
        public virtual DbSet<PurchaseOrderProductTransactionType> PurchaseOrderProductTransactionTypes { get; set; }
        public virtual DbSet<PurchaseOrderReceiving> PurchaseOrderReceivings { get; set; }
        public virtual DbSet<PurchaseOrderReceivingDetail> PurchaseOrderReceivingDetails { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<tblGLBookType> tblGLBookTypes { get; set; }
        public virtual DbSet<tblGLTranDetail> tblGLTranDetails { get; set; }
        public virtual DbSet<tblGLTranHeader> tblGLTranHeaders { get; set; }
        public virtual DbSet<tblJournalEntry> tblJournalEntries { get; set; }
        public virtual DbSet<tblLocation> tblLocations { get; set; }
        public virtual DbSet<tblMasCOA> tblMasCOAs { get; set; }
        public virtual DbSet<tblMasCOAGroup> tblMasCOAGroups { get; set; }
        public virtual DbSet<tblMasCOASub> tblMasCOASubs { get; set; }
        public virtual DbSet<tblTBBatchDtl> tblTBBatchDtls { get; set; }
        public virtual DbSet<tblTBBatchHdr> tblTBBatchHdrs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .Property(e => e.curStartingDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bank>()
                .Property(e => e.curDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bank>()
                .Property(e => e.curCredit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bank>()
                .Property(e => e.curBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Suppliers)
                .WithOptional(e => e.Bank)
                .HasForeignKey(e => e.intIDBank);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Banks)
                .WithOptional(e => e.Currency)
                .HasForeignKey(e => e.intIDCurrency);

            modelBuilder.Entity<Customer>()
                .Property(e => e.curStartingDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.curDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.curCredit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.curCreditLimit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PriceType>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.intIDPriceType);

            modelBuilder.Entity<PriceType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.intIDPriceType);

            modelBuilder.Entity<Product>()
                .Property(e => e.curDefaultCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.curDefaultRetail)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.curDefaultWholesale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.curDefaultMarkup)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductDetails)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.intIDProduct);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.intIDProduct);

            modelBuilder.Entity<ProductBrand>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductBrand)
                .HasForeignKey(e => e.intIDProductBrands);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.intIDProductCategory);

            modelBuilder.Entity<ProductCharacteristic>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCharacteristic)
                .HasForeignKey(e => e.intIDProductCharacteristic);

            modelBuilder.Entity<ProductColor>()
                .HasMany(e => e.ProductDetails)
                .WithOptional(e => e.ProductColor)
                .HasForeignKey(e => e.intIDProductColor);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.curCargoCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.curCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.curRetail)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.curWholesale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.curMarkUp)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProductDetail>()
                .HasOptional(e => e.ProductDetail1)
                .WithRequired(e => e.ProductDetail2);

            modelBuilder.Entity<ProductDetail>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithOptional(e => e.ProductDetail)
                .HasForeignKey(e => e.intIDProductDetail);

            modelBuilder.Entity<ProductSize>()
                .HasMany(e => e.ProductDetails)
                .WithOptional(e => e.ProductSize)
                .HasForeignKey(e => e.intIDProductSize);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.intIDProductType);

            modelBuilder.Entity<PuchaseOrderReceivingStatu>()
                .HasMany(e => e.PurchaseOrders)
                .WithOptional(e => e.PuchaseOrderReceivingStatu)
                .HasForeignKey(e => e.intIDReceivingStatus);

            modelBuilder.Entity<PuchaseOrderReceivingStatu>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithOptional(e => e.PuchaseOrderReceivingStatu)
                .HasForeignKey(e => e.intIDReceivingStatus);

            modelBuilder.Entity<PuchaseOrderReceivingStatu>()
                .HasMany(e => e.PurchaseOrderDetailInventoryLedgers)
                .WithOptional(e => e.PuchaseOrderReceivingStatu)
                .HasForeignKey(e => e.intIDReceivingStatus);

            modelBuilder.Entity<PuchaseOrderReceivingStatu>()
                .HasMany(e => e.PurchaseOrderInventoryLedgers)
                .WithOptional(e => e.PuchaseOrderReceivingStatu)
                .HasForeignKey(e => e.intIDReceivingStatus);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curTotalQty)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curSubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curDiscountPercentage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curGrandTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curTotalPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curTotalReceived)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curTotalRemaining)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curAmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.curChange)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderCustomerLedgers)
                .WithOptional(e => e.PurchaseOrder)
                .HasForeignKey(e => e.intIDPurchaseOrder);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderInventoryLedgers)
                .WithOptional(e => e.PurchaseOrder)
                .HasForeignKey(e => e.intIDPurchaseOrder);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithOptional(e => e.PurchaseOrder)
                .HasForeignKey(e => e.intIDPurchaseOrder);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderPayments)
                .WithOptional(e => e.PurchaseOrder)
                .HasForeignKey(e => e.intIDPurchaseOrder);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curSubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curGrandTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curTotalPaidPendingPayments)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curTotalDiscountsPendingDiscounts)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curTotalChangePendingChange)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .Property(e => e.curTotalBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedger>()
                .HasMany(e => e.PurchaseOrderCustomerLedgerDetails)
                .WithOptional(e => e.PurchaseOrderCustomerLedger)
                .HasForeignKey(e => e.intIDPurchaseOrderCustomerLedger);

            modelBuilder.Entity<PurchaseOrderCustomerLedgerDetail>()
                .Property(e => e.curAmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderCustomerLedgerDetail>()
                .Property(e => e.curChange)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.curCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.curSubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasMany(e => e.PurchaseOrderDetailInventoryLedgers)
                .WithOptional(e => e.PurchaseOrderDetail)
                .HasForeignKey(e => e.intIDPurchaseOrderDetail);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasMany(e => e.PurchaseOrderProductDetailHistories)
                .WithOptional(e => e.PurchaseOrderDetail)
                .HasForeignKey(e => e.intIDPurchaseOrderDetail);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasMany(e => e.PurchaseOrderReceivingDetails)
                .WithOptional(e => e.PurchaseOrderDetail)
                .HasForeignKey(e => e.intIDPurchaseOrderDetail);

            modelBuilder.Entity<PurchaseOrderInventoryLedger>()
                .HasMany(e => e.PurchaseOrderDetailInventoryLedgers)
                .WithOptional(e => e.PurchaseOrderInventoryLedger)
                .HasForeignKey(e => e.intIDPurchaseOrderInventoryLedger);

            modelBuilder.Entity<PurchaseOrderPayment>()
                .Property(e => e.curTotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderPayment>()
                .Property(e => e.curDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderPayment>()
                .Property(e => e.curGrandTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderPayment>()
                .Property(e => e.curAmountPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderProductTransactionType>()
                .HasMany(e => e.PurchaseOrderProductDetailHistories)
                .WithOptional(e => e.PurchaseOrderProductTransactionType)
                .HasForeignKey(e => e.intIDPurchaseOrderProductTransactionType);

            modelBuilder.Entity<PurchaseOrderReceiving>()
                .HasMany(e => e.PurchaseOrderReceivingDetails)
                .WithOptional(e => e.PurchaseOrderReceiving)
                .HasForeignKey(e => e.intIDPurchaseOrderReceiving);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.curStartingDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.curDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.curCredit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.curBalance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PurchaseOrders)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.intIDSupplier);

            //modelBuilder.Entity<tblGLBookType>()
            //    .Property(e => e.sampleColumn)
            //    .IsFixedLength();

            modelBuilder.Entity<tblGLTranDetail>()
                .Property(e => e.curDebit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblGLTranDetail>()
                .Property(e => e.curCredit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblGLTranHeader>()
                .Property(e => e.curCreditAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblGLTranHeader>()
                .Property(e => e.curDebitAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblGLTranHeader>()
                .HasMany(e => e.tblGLTranDetails)
                .WithRequired(e => e.tblGLTranHeader)
                .HasForeignKey(e => e.intIDGLTranHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblLocation>()
                .HasMany(e => e.PurchaseOrders)
                .WithOptional(e => e.tblLocation)
                .HasForeignKey(e => e.intIDLocation);

            modelBuilder.Entity<tblMasCOA>()
                .Property(e => e.strCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblMasCOA>()
                .Property(e => e.strName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMasCOA>()
                .Property(e => e.strAcctSide)
                .IsFixedLength();

            modelBuilder.Entity<tblMasCOA>()
                .Property(e => e.strAcctType)
                .IsFixedLength();

            modelBuilder.Entity<tblMasCOA>()
                .HasMany(e => e.tblMasCOASubs)
                .WithOptional(e => e.tblMasCOA)
                .HasForeignKey(e => e.intIDMasCOA);

            modelBuilder.Entity<tblMasCOAGroup>()
                .Property(e => e.strCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblMasCOAGroup>()
                .Property(e => e.strName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMasCOASub>()
                .Property(e => e.strCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblMasCOASub>()
                .Property(e => e.strName)
                .IsUnicode(false);

            modelBuilder.Entity<tblTBBatchHdr>()
                .HasMany(e => e.tblTBBatchDtls)
                .WithRequired(e => e.tblTBBatchHdr)
                .HasForeignKey(e => e.intIDTBBatchHdr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PurchaseOrders)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.intIDApprover);

            modelBuilder.Entity<tblGLBookType>()
              .HasMany(e => e.tblGLTranHeaders)
              .WithRequired(e => e.tblGLBookType)
              .HasForeignKey(e => e.intIDGLBookType)
              .WillCascadeOnDelete(false);


        }
    }
}
