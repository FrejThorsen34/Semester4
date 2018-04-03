namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTypeUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddressTypes", "Person_Id", "dbo.People");
            DropIndex("dbo.AddressTypes", new[] { "Person_Id" });
            RenameColumn(table: "dbo.AddressTypes", name: "Person_Id", newName: "PersonId");
            AlterColumn("dbo.AddressTypes", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.AddressTypes", "PersonId");
            AddForeignKey("dbo.AddressTypes", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressTypes", "PersonId", "dbo.People");
            DropIndex("dbo.AddressTypes", new[] { "PersonId" });
            AlterColumn("dbo.AddressTypes", "PersonId", c => c.Int());
            RenameColumn(table: "dbo.AddressTypes", name: "PersonId", newName: "Person_Id");
            CreateIndex("dbo.AddressTypes", "Person_Id");
            AddForeignKey("dbo.AddressTypes", "Person_Id", "dbo.People", "Id");
        }
    }
}
