namespace I4DABH1NE84070.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Countries", new[] { "Organization_OrganizationId" });
            CreateTable(
                "dbo.OrganizationCountries",
                c => new
                    {
                        Organization_OrganizationId = c.Int(nullable: false),
                        Country_CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationId, t.Country_CountryId })
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationId)
                .Index(t => t.Country_CountryId);
            
            DropColumn("dbo.Countries", "Organization_OrganizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Organization_OrganizationId", c => c.Int());
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryId" });
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationId" });
            DropTable("dbo.OrganizationCountries");
            CreateIndex("dbo.Countries", "Organization_OrganizationId");
            AddForeignKey("dbo.Countries", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId");
        }
    }
}
