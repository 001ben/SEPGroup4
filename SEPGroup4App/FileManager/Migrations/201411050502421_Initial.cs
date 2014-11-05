namespace FileManagerNs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationDbFiles",
                c => new
                    {
                        ApplicationDbFilesId = c.Int(nullable: false, identity: true),
                        ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationDbFilesId);
            
            CreateTable(
                "dbo.ApplicationDbFile",
                c => new
                    {
                        ApplicationDbFileId = c.Int(nullable: false, identity: true),
                        ApplicationDbFilesId = c.Int(nullable: false),
                        Data = c.Binary(),
                        FileName = c.String(),
                        MimeType = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationDbFileId)
                .ForeignKey("dbo.ApplicationDbFiles", t => t.ApplicationDbFilesId, cascadeDelete: true)
                .Index(t => t.ApplicationDbFilesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationDbFile", "ApplicationDbFilesId", "dbo.ApplicationDbFiles");
            DropIndex("dbo.ApplicationDbFile", new[] { "ApplicationDbFilesId" });
            DropTable("dbo.ApplicationDbFile");
            DropTable("dbo.ApplicationDbFiles");
        }
    }
}
