namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class previouscustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateForm", "PreviousCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.EstimateForm", "PreviousCustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EstimateForm", "PreviousCustomerName");
            DropColumn("dbo.EstimateForm", "PreviousCustomer");
        }
    }
}
