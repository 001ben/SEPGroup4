namespace SEPGroup4App.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialApplications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SchoolUnit = c.String(),
                        Supervisor = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ApplicantType = c.Int(),
                        FirstApplicationThisYear = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        Submitted = c.Boolean(nullable: false),
                        SubmittedOn = c.DateTime(),
                        StaffStudentId = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.FundingDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        ResearchGrant = c.Boolean(),
                        ResearchStudent = c.Boolean(),
                        ResearchStrength = c.String(),
                        StrengthSupport = c.Boolean(),
                        Stage = c.Int(),
                        SupervisorGrant = c.Boolean(),
                        AppliedtoVCFund = c.Boolean(),
                        VCFundGrantAmount = c.Decimal(precision: 18, scale: 2),
                        Airfare = c.Decimal(precision: 18, scale: 2),
                        Accomodation = c.Decimal(precision: 18, scale: 2),
                        ConferenceFees = c.Decimal(precision: 18, scale: 2),
                        Meals = c.Decimal(precision: 18, scale: 2),
                        LocalFares = c.Decimal(precision: 18, scale: 2),
                        CarMileage = c.Decimal(precision: 18, scale: 2),
                        Other = c.Decimal(precision: 18, scale: 2),
                        TotalExpenses = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.TravelDetails",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        PaperType = c.Int(),
                        DepartureDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                        JustificationForTravel = c.String(),
                        PEPArrangements = c.Boolean(nullable: false),
                        PEPStartDate = c.DateTime(),
                        PEPEndDate = c.DateTime(),
                        ConferenceNameDetails = c.String(),
                        ConferenceURL = c.String(),
                        ConferenceStartDate = c.DateTime(),
                        ConferenceEndDate = c.DateTime(),
                        Country = c.String(),
                        Region = c.String(),
                        City = c.String(),
                        Quality = c.Int(),
                        SpecialDuties = c.Int(),
                        PaperTitle = c.String(),
                        PaperAccepted = c.Boolean(nullable: false),
                        AttachedDocuments = c.Int(),
                        HERDCPoints = c.Boolean(nullable: false),
                        PublicationImportanceAndQuality = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantDetails", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.TravelDetails", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.FundingDetails", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.TravelDetails", new[] { "ApplicationId" });
            DropIndex("dbo.FundingDetails", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicantDetails", new[] { "ApplicationId" });
            DropTable("dbo.TravelDetails");
            DropTable("dbo.FundingDetails");
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicantDetails");
        }
    }
}
