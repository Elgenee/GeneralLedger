namespace GeneralLedger.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        StartingDebit = c.Decimal(storeType: "money"),
                        Contact = c.String(maxLength: 500),
                        Address = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agents");
        }
    }
}
