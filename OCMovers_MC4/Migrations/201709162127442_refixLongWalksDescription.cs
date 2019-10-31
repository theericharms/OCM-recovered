namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refixLongWalksDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "LongWalksDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "LongWalksDescription");
        }
    }
}
