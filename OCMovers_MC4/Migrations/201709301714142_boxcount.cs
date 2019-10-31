namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boxcount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "BoxCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "BoxCount");
        }
    }
}
