namespace I4DABH1NE84070.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        display_name = c.String(),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            DropColumn("dbo.Organizations", "Username");
            DropColumn("dbo.Organizations", "display_name");
            DropColumn("dbo.Organizations", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Organizations", "display_name", c => c.String());
            AddColumn("dbo.Organizations", "Username", c => c.String());
            DropForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Users", new[] { "OrganizationId" });
            DropTable("dbo.Users");
        }
    }
}
