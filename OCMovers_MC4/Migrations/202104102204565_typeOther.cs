namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeOther : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "OtherCurrent", c => c.String());
            AddColumn("dbo.EstimateForm", "OtherDestination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "OtherDestination");
            DropColumn("dbo.EstimateForm", "OtherCurrent");
        }
    }
}
