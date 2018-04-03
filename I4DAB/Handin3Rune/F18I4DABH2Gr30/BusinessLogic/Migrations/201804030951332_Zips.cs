namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zips : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Addresses", "ZipId", c => c.String());
            AddColumn("dbo.Addresses", "Zip_Zipcode", c => c.String(maxLength: 128));
            AddColumn("dbo.PrimaryAddresses", "ZipId", c => c.String());
            AddColumn("dbo.PrimaryAddresses", "Zip_Zipcode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Addresses", "Zip_Zipcode");
            CreateIndex("dbo.PrimaryAddresses", "Zip_Zipcode");
            AddForeignKey("dbo.Addresses", "Zip_Zipcode", "dbo.Zips", "Zipcode");
            AddForeignKey("dbo.PrimaryAddresses", "Zip_Zipcode", "dbo.Zips", "Zipcode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "Zip_Zipcode", "dbo.Zips");
            DropForeignKey("dbo.Addresses", "Zip_Zipcode", "dbo.Zips");
            DropIndex("dbo.PrimaryAddresses", new[] { "Zip_Zipcode" });
            DropIndex("dbo.Addresses", new[] { "Zip_Zipcode" });
            DropColumn("dbo.PrimaryAddresses", "Zip_Zipcode");
            DropColumn("dbo.PrimaryAddresses", "ZipId");
            DropColumn("dbo.Addresses", "Zip_Zipcode");
            DropColumn("dbo.Addresses", "ZipId");
            DropTable("dbo.Zips");
        }
    }
}
