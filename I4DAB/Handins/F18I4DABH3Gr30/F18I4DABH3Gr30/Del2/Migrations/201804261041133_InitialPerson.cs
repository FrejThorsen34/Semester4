namespace Del2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialPerson : DbMigration
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
                        Zip_Zipcode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.Zip_Zipcode)
                .Index(t => t.Zip_Zipcode);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Type = c.String(),
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
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        PersonType = c.String(),
                        Email = c.String(),
                        PrimaryAddress_Id = c.Int(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrimaryAddresses", t => t.PrimaryAddress_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.PrimaryAddress_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneType = c.String(),
                        Number = c.String(),
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
                        Street = c.String(),
                        StreetNumber = c.String(),
                        Zip_Zipcode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zips", t => t.Zip_Zipcode)
                .Index(t => t.Zip_Zipcode);
            
            CreateTable(
                "dbo.Zips",
                c => new
                    {
                        Zipcode = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                        Town = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Zipcode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.AddressTypes", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "PrimaryAddress_Id", "dbo.PrimaryAddresses");
            DropForeignKey("dbo.PrimaryAddresses", "Zip_Zipcode", "dbo.Zips");
            DropForeignKey("dbo.Addresses", "Zip_Zipcode", "dbo.Zips");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PrimaryAddresses", new[] { "Zip_Zipcode" });
            DropIndex("dbo.PhoneNumbers", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropIndex("dbo.People", new[] { "PrimaryAddress_Id" });
            DropIndex("dbo.AddressTypes", new[] { "PersonId" });
            DropIndex("dbo.AddressTypes", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "Zip_Zipcode" });
            DropTable("dbo.Zips");
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
