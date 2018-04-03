namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryAddresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Type = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.AddressId)
                .Index(t => t.Person_Id);
            
            AddColumn("dbo.People", "Address_Id", c => c.Int());
            CreateIndex("dbo.People", "Address_Id");
            AddForeignKey("dbo.People", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.AddressTypes", "Person_Id", "dbo.People");
            DropForeignKey("dbo.AddressTypes", "AddressId", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropIndex("dbo.AddressTypes", new[] { "Person_Id" });
            DropIndex("dbo.AddressTypes", new[] { "AddressId" });
            DropColumn("dbo.People", "Address_Id");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
