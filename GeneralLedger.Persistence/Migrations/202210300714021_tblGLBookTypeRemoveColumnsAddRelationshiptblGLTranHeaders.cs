namespace GeneralLedger.Persistence.EntityConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblGLBookTypeRemoveColumnsAddRelationshiptblGLTranHeaders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblGLTranHeader", "intIDGLBookType", c => c.Int(nullable: false));
            CreateIndex("dbo.tblGLTranHeader", "intIDGLBookType");
            AddForeignKey("dbo.tblGLTranHeader", "intIDGLBookType", "dbo.tblGLBookType", "ID");
            DropColumn("dbo.tblGLBookType", "sampleColumn");
            DropColumn("dbo.tblGLBookType", "sampleCOlumn1");
            DropColumn("dbo.tblGLBookType", "sampleColumn2");
            DropColumn("dbo.tblGLBookType", "sampleColumn3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblGLBookType", "sampleColumn3", c => c.Int());
            AddColumn("dbo.tblGLBookType", "sampleColumn2", c => c.Int());
            AddColumn("dbo.tblGLBookType", "sampleCOlumn1", c => c.Int());
            AddColumn("dbo.tblGLBookType", "sampleColumn", c => c.String(maxLength: 10, fixedLength: true));
            DropForeignKey("dbo.tblGLTranHeader", "intIDGLBookType", "dbo.tblGLBookType");
            DropIndex("dbo.tblGLTranHeader", new[] { "intIDGLBookType" });
            AlterColumn("dbo.tblGLTranHeader", "intIDGLBookType", c => c.Int());
        }
    }
}
