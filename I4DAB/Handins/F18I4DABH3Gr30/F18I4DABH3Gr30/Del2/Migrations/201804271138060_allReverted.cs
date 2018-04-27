namespace Del2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allReverted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        StreetNumber = c.String(nullable: false),
                        ZipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.ZipId, cascadeDelete: true)
                .Index(t => t.ZipId);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        PersonType = c.String(),
                        Email = c.String(),
                        PrimaryAddressId = c.Int(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrimaryAddresses", t => t.PrimaryAddressId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.PrimaryAddressId)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneType = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        Provider = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PrimaryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        StreetNumber = c.String(nullable: false),
                        ZipId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.ZipId)
                .Index(t => t.ZipId);
            
            CreateTable(
                "dbo.Zips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.AddressTypes", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "PrimaryAddressId", "dbo.PrimaryAddresses");
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.Addresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PrimaryAddresses", new[] { "ZipId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropIndex("dbo.People", new[] { "PrimaryAddressId" });
            DropIndex("dbo.AddressTypes", new[] { "PersonId" });
            DropIndex("dbo.AddressTypes", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "ZipId" });
            DropTable("dbo.Zips");
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
