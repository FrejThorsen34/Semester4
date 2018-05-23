namespace SmartGridInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Distance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmartMeters",
                c => new
                    {
                        SerialNumber = c.String(nullable: false, maxLength: 128),
                        ProsumerId = c.String(),
                    })
                .PrimaryKey(t => t.SerialNumber);
            
            CreateTable(
                "dbo.SmartMeterConnections",
                c => new
                    {
                        SmartMeter_SerialNumber = c.String(nullable: false, maxLength: 128),
                        Connection_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SmartMeter_SerialNumber, t.Connection_Id })
                .ForeignKey("dbo.SmartMeters", t => t.SmartMeter_SerialNumber, cascadeDelete: true)
                .ForeignKey("dbo.Connections", t => t.Connection_Id, cascadeDelete: true)
                .Index(t => t.SmartMeter_SerialNumber)
                .Index(t => t.Connection_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartMeterConnections", "Connection_Id", "dbo.Connections");
            DropForeignKey("dbo.SmartMeterConnections", "SmartMeter_SerialNumber", "dbo.SmartMeters");
            DropIndex("dbo.SmartMeterConnections", new[] { "Connection_Id" });
            DropIndex("dbo.SmartMeterConnections", new[] { "SmartMeter_SerialNumber" });
            DropTable("dbo.SmartMeterConnections");
            DropTable("dbo.SmartMeters");
            DropTable("dbo.Connections");
        }
    }
}
