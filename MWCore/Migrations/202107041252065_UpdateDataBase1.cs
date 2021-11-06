namespace MWCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MW_Cars", "PlateNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MW_Cars", "PlateNumber", c => c.Int(nullable: false));
        }
    }
}
