namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aptmultiplelevels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddress", "ApartemntMultipleLevels", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAddress", "ApartemntMultipleLevels");
        }
    }
}
