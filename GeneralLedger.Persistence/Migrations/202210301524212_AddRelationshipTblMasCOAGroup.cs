namespace GeneralLedger.Persistence.EntityConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipTblMasCOAGroup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblMasCOA", "intIDMasCOAGroup", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMasCOA", "intIDMasCOAGroup");
            AddForeignKey("dbo.tblMasCOA", "intIDMasCOAGroup", "dbo.tblMasCOAGroup", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMasCOA", "intIDMasCOAGroup", "dbo.tblMasCOAGroup");
            DropIndex("dbo.tblMasCOA", new[] { "intIDMasCOAGroup" });
            AlterColumn("dbo.tblMasCOA", "intIDMasCOAGroup", c => c.Int());
        }
    }
}
