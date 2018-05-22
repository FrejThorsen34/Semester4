using ProsumerInfo.Models;

namespace ProsumerInfo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProsumerInfo.Models.ProsumerInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProsumerInfo.Models.ProsumerInfoContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			Identity husstand1 = new Identity() { Id = "1", Name = "husstand1", Type = "bolig", Address = "Vej1, SmartVillage"};

	        context.Identities.AddOrUpdate(x => x.Id, husstand1);

			Prosumer prosumer1 = new Prosumer()
	        {
		        Id = "1",
		        Identity = husstand1,
		        IdentityId = "1",
		        Production = 2,
		        Consumption = 1,
		        Balance = 1,
		        SmartMeterSerialNumber = "1"
	        };

			context.Prosumers.AddOrUpdate(x=>x.Id,prosumer1);

		}
	}
}
