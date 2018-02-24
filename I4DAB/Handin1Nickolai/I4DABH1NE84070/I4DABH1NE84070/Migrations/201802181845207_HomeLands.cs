namespace I4DABH1NE84070.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeLands : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryId" });
            AddColumn("dbo.Countries", "Organization_OrganizationId", c => c.Int());
            CreateIndex("dbo.Countries", "Organization_OrganizationId");
            AddForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId");
            DropColumn("dbo.Organizations", "Homeland_CountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Homeland_CountryId", c => c.Int());
            DropForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Countries", new[] { "Organization_OrganizationId" });
            DropColumn("dbo.Countries", "Organization_OrganizationId");
            CreateIndex("dbo.Organizations", "Homeland_CountryId");
            AddForeignKey("dbo.Organizations", "Homeland_CountryId", "dbo.Countries", "CountryId");
        }
    }
}
