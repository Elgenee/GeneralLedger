namespace GeneralLedger.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationTblGLTranHeaderTblJournalEntry : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tblGLTranHeader", "intIDReference");
            AddForeignKey("dbo.tblGLTranHeader", "intIDReference", "dbo.tblJournalEntry", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblGLTranHeader", "intIDReference", "dbo.tblJournalEntry");
            DropIndex("dbo.tblGLTranHeader", new[] { "intIDReference" });
        }
    }
}
