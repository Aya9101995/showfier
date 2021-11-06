namespace MWCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MW_AdditionalServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MW_AdditionalServices_Loc",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ServiceID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MW_AdditionalServices", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MW_AdditionalServices_Loc", "ServiceID", "dbo.MW_AdditionalServices");
            DropIndex("dbo.MW_AdditionalServices_Loc", new[] { "ServiceID" });
            DropTable("dbo.MW_AdditionalServices_Loc");
            DropTable("dbo.MW_AdditionalServices");
        }
    }
}
