namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryAddressCorrected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StreetNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "StreetNumber");
        }
    }
}
