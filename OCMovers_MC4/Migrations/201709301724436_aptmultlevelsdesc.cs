namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aptmultlevelsdesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "ApartmentMultipleLevelsDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "ApartmentMultipleLevelsDescription");
        }
    }
}
