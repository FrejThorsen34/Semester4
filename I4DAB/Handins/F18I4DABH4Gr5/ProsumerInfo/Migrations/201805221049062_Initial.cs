namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prosumers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SmartMeterSerialNumber = c.String(),
                        IdentityId = c.String(nullable: false, maxLength: 128),
                        Production = c.Double(nullable: false),
                        Consumption = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Identities", t => t.IdentityId, cascadeDelete: true)
                .Index(t => t.IdentityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prosumers", "IdentityId", "dbo.Identities");
            DropIndex("dbo.Prosumers", new[] { "IdentityId" });
            DropTable("dbo.Prosumers");
            DropTable("dbo.Identities");
        }
    }
}
