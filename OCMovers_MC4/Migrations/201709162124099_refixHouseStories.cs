namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refixHouseStories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "HouseStories", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "HouseStories");
        }
    }
}
