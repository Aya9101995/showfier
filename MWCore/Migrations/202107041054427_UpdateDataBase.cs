namespace MWCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MW_Cars", "MakeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MW_Cars", "MakeID", c => c.Int(nullable: false));
        }
    }
}
