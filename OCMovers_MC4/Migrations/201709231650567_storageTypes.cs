namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storageTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "StorageType", c => c.String());
            AddColumn("dbo.CustomerAddress", "StorageLongWalks", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerAddress", "StorageLongWalksDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "StorageLongWalksDescription");
            DropColumn("dbo.CustomerAddress", "StorageLongWalks");
            DropColumn("dbo.CustomerAddress", "StorageType");
        }
    }
}
