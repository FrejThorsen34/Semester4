namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimaryAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrimaryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        StreetNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "PrimaryAddress_Id", c => c.Int());
            CreateIndex("dbo.People", "PrimaryAddress_Id");
            AddForeignKey("dbo.People", "PrimaryAddress_Id", "dbo.PrimaryAddresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PrimaryAddress_Id", "dbo.PrimaryAddresses");
            DropIndex("dbo.People", new[] { "PrimaryAddress_Id" });
            DropColumn("dbo.People", "PrimaryAddress_Id");
            DropTable("dbo.PrimaryAddresses");
        }
    }
}
