namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixHouseStories : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerAddress", "HouseStories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerAddress", "HouseStories", c => c.Int(nullable: false));
        }
    }
}
