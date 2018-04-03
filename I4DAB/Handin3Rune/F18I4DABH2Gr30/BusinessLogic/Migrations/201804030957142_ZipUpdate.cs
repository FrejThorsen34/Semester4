namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZipUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "ZipId");
            DropColumn("dbo.PrimaryAddresses", "ZipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrimaryAddresses", "ZipId", c => c.String());
            AddColumn("dbo.Addresses", "ZipId", c => c.String());
        }
    }
}
