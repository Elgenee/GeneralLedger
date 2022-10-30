namespace GeneralLedger.Persistence.EntityConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationTblSalesUpdateTransactionDate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropColumn("dbo.Sales", "intIdCustomer");
            RenameColumn(table: "dbo.Sales", name: "Customer_Id", newName: "intIdCustomer");
            AddColumn("dbo.Sales", "TransactionDate", c => c.DateTime());
            AlterColumn("dbo.Sales", "intIdCustomer", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "intIdCustomer");
            AddForeignKey("dbo.Sales", "intIdCustomer", "dbo.Customer", "Id", cascadeDelete: true);
            DropColumn("dbo.Sales", "datBatchDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "datBatchDate", c => c.DateTime());
            DropForeignKey("dbo.Sales", "intIdCustomer", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "intIdCustomer" });
            AlterColumn("dbo.Sales", "intIdCustomer", c => c.Int());
            DropColumn("dbo.Sales", "TransactionDate");
            RenameColumn(table: "dbo.Sales", name: "intIdCustomer", newName: "Customer_Id");
            AddColumn("dbo.Sales", "intIdCustomer", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "Customer_Id");
            AddForeignKey("dbo.Sales", "Customer_Id", "dbo.Customer", "Id");
        }
    }
}
