namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "Feedback", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "Feedback");
        }
    }
}
