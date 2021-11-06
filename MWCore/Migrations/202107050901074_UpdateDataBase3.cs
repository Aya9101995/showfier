namespace MWCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MW_CarAdditionalServices",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ServiceID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhoneCode = c.String(),
                        PhoneNumber = c.String(),
                        FullName = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        Password = c.String(),
                        Picture = c.String(),
                        CivilID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        DefaultCarID = c.Int(nullable: false),
                        TodaysCarID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CanAcceptRejectTrips = c.Boolean(nullable: false),
                        DefaultLanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_Cars", t => t.DefaultCarID, cascadeDelete: true)
                .Index(t => t.DefaultCarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MW_Drivers", "DefaultCarID", "dbo.MW_Cars");
            DropIndex("dbo.MW_Drivers", new[] { "DefaultCarID" });
            DropTable("dbo.MW_Drivers");
            DropTable("dbo.MW_CarAdditionalServices");
        }
    }
}
