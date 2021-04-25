namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "StorageTypeCurrent", c => c.String());
            AddColumn("dbo.EstimateForm", "StorageTypeDestination", c => c.String());
            AddColumn("dbo.EstimateForm", "StorageGroundFloorAccessCurrent", c => c.String());
            AddColumn("dbo.EstimateForm", "StorageGroundFloorAccessDestination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "StorageGroundFloorAccessDestination");
            DropColumn("dbo.EstimateForm", "StorageGroundFloorAccessCurrent");
            DropColumn("dbo.EstimateForm", "StorageTypeDestination");
            DropColumn("dbo.EstimateForm", "StorageTypeCurrent");
        }
    }
}
