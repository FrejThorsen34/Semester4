namespace Del2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PrimaryAddress_Id", "dbo.PrimaryAddresses");
            DropIndex("dbo.People", new[] { "PrimaryAddress_Id" });
            RenameColumn(table: "dbo.People", name: "PrimaryAddress_Id", newName: "PrimaryAddressId");
            AlterColumn("dbo.People", "PrimaryAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "PrimaryAddressId");
            AddForeignKey("dbo.People", "PrimaryAddressId", "dbo.PrimaryAddresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PrimaryAddressId", "dbo.PrimaryAddresses");
            DropIndex("dbo.People", new[] { "PrimaryAddressId" });
            AlterColumn("dbo.People", "PrimaryAddressId", c => c.Int());
            RenameColumn(table: "dbo.People", name: "PrimaryAddressId", newName: "PrimaryAddress_Id");
            CreateIndex("dbo.People", "PrimaryAddress_Id");
            AddForeignKey("dbo.People", "PrimaryAddress_Id", "dbo.PrimaryAddresses", "Id");
        }
    }
}
