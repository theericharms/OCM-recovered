namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAddressTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "HouseOrApt", c => c.String());
            AddColumn("dbo.CustomerAddress", "HouseStories", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAddress", "AptFloor", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAddress", "ElevatorStairs", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "ElevatorStairsDescription", c => c.String());
            AddColumn("dbo.CustomerAddress", "Stairs", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "StairsDescription", c => c.String());
            AddColumn("dbo.CustomerAddress", "LongWalks", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "LongWalksDescription", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "NumberOfBedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAddress", "Inventory", c => c.String());
            AddColumn("dbo.CustomerAddress", "SpecialCare", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "SpecialCareDescription", c => c.String());
            AddColumn("dbo.CustomerAddress", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "Notes");
            DropColumn("dbo.CustomerAddress", "SpecialCareDescription");
            DropColumn("dbo.CustomerAddress", "SpecialCare");
            DropColumn("dbo.CustomerAddress", "Inventory");
            DropColumn("dbo.CustomerAddress", "NumberOfBedrooms");
            DropColumn("dbo.CustomerAddress", "LongWalksDescription");
            DropColumn("dbo.CustomerAddress", "LongWalks");
            DropColumn("dbo.CustomerAddress", "StairsDescription");
            DropColumn("dbo.CustomerAddress", "Stairs");
            DropColumn("dbo.CustomerAddress", "ElevatorStairsDescription");
            DropColumn("dbo.CustomerAddress", "ElevatorStairs");
            DropColumn("dbo.CustomerAddress", "AptFloor");
            DropColumn("dbo.CustomerAddress", "HouseStories");
            DropColumn("dbo.CustomerAddress", "HouseOrApt");
        }
    }
}
