namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storagegroundfloorelevator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "StorageGroundFloorElevator", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "StorageGroundFloorElevator");
        }
    }
}
