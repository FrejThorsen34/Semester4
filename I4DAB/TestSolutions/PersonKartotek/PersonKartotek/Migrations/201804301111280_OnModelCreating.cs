namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnModelCreating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.PersonAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropIndex("dbo.People", new[] { "PrimaryAddressId" });
            AlterColumn("dbo.People", "PrimaryAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PrimaryAddressId");
            AddForeignKey("dbo.PersonAddresses", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Addresses", "ZipId", "dbo.Zips", "Id");
            AddForeignKey("dbo.PersonAddresses", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.Addresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.PersonAddresses", "AddressId", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "PrimaryAddressId" });
            AlterColumn("dbo.People", "PrimaryAddressId", c => c.Int());
            CreateIndex("dbo.People", "PrimaryAddressId");
            AddForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonAddresses", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "ZipId", "dbo.Zips", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonAddresses", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
