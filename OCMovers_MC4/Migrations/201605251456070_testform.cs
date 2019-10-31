namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "test");
        }
    }
}
