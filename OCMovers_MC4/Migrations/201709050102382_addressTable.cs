namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddress",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        EstimateId = c.Int(nullable: false),
                        AddressType = c.String(),
                        BuildingName = c.String(),
                        Address1 = c.String(),
                        AptNum = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerAddress");
        }
    }
}
