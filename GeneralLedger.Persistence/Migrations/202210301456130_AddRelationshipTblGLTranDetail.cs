namespace GeneralLedger.Persistence.EntityConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipTblGLTranDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblGLTranDetail", "intIDMasCoaSub", c => c.Int(nullable: false));
            CreateIndex("dbo.tblGLTranDetail", "intIDMasCoa");
            CreateIndex("dbo.tblGLTranDetail", "intIDMasCoaSub");
            AddForeignKey("dbo.tblGLTranDetail", "intIDMasCoa", "dbo.tblMasCOA", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblGLTranDetail", "intIDMasCoaSub", "dbo.tblMasCOASub", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblGLTranDetail", "intIDMasCoaSub", "dbo.tblMasCOASub");
            DropForeignKey("dbo.tblGLTranDetail", "intIDMasCoa", "dbo.tblMasCOA");
            DropIndex("dbo.tblGLTranDetail", new[] { "intIDMasCoaSub" });
            DropIndex("dbo.tblGLTranDetail", new[] { "intIDMasCoa" });
            AlterColumn("dbo.tblGLTranDetail", "intIDMasCoaSub", c => c.Int());
        }
    }
}
