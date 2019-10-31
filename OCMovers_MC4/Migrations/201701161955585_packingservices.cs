namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packingservices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "packingServices", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "packingServices");
        }
    }
}
