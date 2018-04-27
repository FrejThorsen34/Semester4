namespace Del2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class almostDone1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropIndex("dbo.PrimaryAddresses", new[] { "ZipId" });
            AlterColumn("dbo.PrimaryAddresses", "ZipId", c => c.Int(nullable: false));
            CreateIndex("dbo.PrimaryAddresses", "ZipId");
            AddForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PrimaryAddresses", new[] { "ZipId" });
            AlterColumn("dbo.PrimaryAddresses", "ZipId", c => c.Int());
            CreateIndex("dbo.PrimaryAddresses", "ZipId");
            AddForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips", "Id");
            AddForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
