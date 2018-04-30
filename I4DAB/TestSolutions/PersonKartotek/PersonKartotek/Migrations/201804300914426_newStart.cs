namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        ZipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.ZipId, cascadeDelete: true)
                .Index(t => t.ZipId);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PrimaryAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrimaryAddresses", t => t.PrimaryAddressId)
                .Index(t => t.PrimaryAddressId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(),
                        PhoneType = c.String(),
                        Number = c.String(),
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
                        Street = c.String(),
                        StreetNumber = c.String(),
                        ZipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.ZipId, cascadeDelete: true)
                .Index(t => t.ZipId);
            
            CreateTable(
                "dbo.Zips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        Town = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.PrimaryAddresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.Addresses", "ZipId", "dbo.Zips");
            DropForeignKey("dbo.People", "PrimaryAddressId", "dbo.PrimaryAddresses");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonAddresses", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PrimaryAddresses", new[] { "ZipId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "PrimaryAddressId" });
            DropIndex("dbo.PersonAddresses", new[] { "AddressId" });
            DropIndex("dbo.PersonAddresses", new[] { "PersonId" });
            DropIndex("dbo.Addresses", new[] { "ZipId" });
            DropTable("dbo.Zips");
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.Addresses");
        }
    }
}
