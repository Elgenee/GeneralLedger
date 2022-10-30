namespace GeneralLedger.Persistence.EntityConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaleColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "datBatchDate", c => c.DateTime());
            AddColumn("dbo.Sales", "TRANo", c => c.String(maxLength: 500));
            AddColumn("dbo.Sales", "PONo", c => c.String(maxLength: 500));
            AddColumn("dbo.Sales", "intIdCustomer", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Total", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.Sales", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Sales", "Customer_Id");
            AddForeignKey("dbo.Sales", "Customer_Id", "dbo.Customer", "Id");
            DropColumn("dbo.Sales", "ORNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ORNo", c => c.String(maxLength: 500));
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropColumn("dbo.Sales", "Customer_Id");
            DropColumn("dbo.Sales", "Total");
            DropColumn("dbo.Sales", "intIdCustomer");
            DropColumn("dbo.Sales", "PONo");
            DropColumn("dbo.Sales", "TRANo");
            DropColumn("dbo.Sales", "datBatchDate");
        }
    }
}
