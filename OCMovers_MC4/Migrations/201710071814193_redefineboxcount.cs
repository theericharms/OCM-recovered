namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redefineboxcount : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.CustomerAddress DROP CONSTRAINT DF__CustomerA__BoxCo__160F4887");
            AlterColumn("dbo.CustomerAddress", "BoxCount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerAddress", "BoxCount", c => c.Int(nullable: false));
        }
    }
}
