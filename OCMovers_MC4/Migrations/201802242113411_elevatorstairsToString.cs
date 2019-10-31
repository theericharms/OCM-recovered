namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elevatorstairsToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerAddress", "ElevatorStairs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerAddress", "ElevatorStairs", c => c.Boolean(nullable: false));
        }
    }
}
