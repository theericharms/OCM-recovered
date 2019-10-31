namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestoragegroundfloorelevator : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.CustomerAddress DROP DF__CustomerA__Stora__17036CC0");
            AlterColumn("dbo.CustomerAddress", "StorageGroundFloorElevator", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerAddress", "StorageGroundFloorElevator", c => c.Boolean(nullable: false));
        }
    }
}
