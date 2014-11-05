namespace SEPGroup4App.UserMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        StaffStudentID = c.String(),
                        Email = c.String(),
                        UserName = c.String(),
                        Surname = c.String(),
                        FirstName = c.String(),
                        SchoolUnit = c.String(),
                        Supervisor = c.String(),
                        Phone = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
