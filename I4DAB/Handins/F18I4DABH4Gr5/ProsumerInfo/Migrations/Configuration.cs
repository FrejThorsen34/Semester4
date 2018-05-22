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
			/*
			var identity1 = new Identity() { Id = $"1", Name = $"husstand1", Type = "bolig", Address = $"Vej1, SmartVillage" };
	        var identity2 = new Identity() { Id = $"2", Name = $"husstand2", Type = "bolig", Address = $"Vej2, SmartVillage" };
	        var identity3 = new Identity() { Id = $"3", Name = $"husstand3", Type = "bolig", Address = $"Vej3, SmartVillage" };
	        var identity4 = new Identity() { Id = $"4", Name = $"husstand4", Type = "bolig", Address = $"Vej4, SmartVillage" };
	        var identity1 = new Identity() { Id = $"1", Name = $"husstand1", Type = "bolig", Address = $"Vej1, SmartVillage" };
			*/
			
			/*
	        Identity[] identities = new Identity[47];

	        for (int i = 1; i < 34; i++)
	        {
		        identities[i-1] = new Identity() { Id = $"{i}", Name = $"husstand{i}", Type = "bolig", Address = $"Vej{i}, SmartVillage" };
		        
			}

	        var j = 1;
	        for (int i = 34; i < 46; i++)
	        {
				identities[i-1] = new Identity() { Id = $"{i}", Name = $"virksomhed{j}", Type = "virksomhed", Address = $"Vej{i}, SmartVillage" };
		        j++;
	        }

			identities[45] =  new Identity()
	        {
		        Id = "46",
		        Name = "Dyppekogerbuffer",
		        Type = "Dyppekogerbuffer",
		        Address = "Dyppekogerbuffer, SmartVillage"
	        };

	        identities[46] = new Identity()
	        {
		        Id = "47",
		        Name = "NationalGrid",
		        Type = "NationalGrid",
		        Address = "No address"
	        };

	        context.Identities.AddOrUpdate(x=>x.Id, identities);

	        Prosumer[] prosumers = new Prosumer[47];
			
			for (int i = 1; i < 47; i++)
	        {
				prosumers[i-1] = new Prosumer()
		        {
			        Id = $"{i}",
			        Identity = identities[i-1],
			        IdentityId =$"{i}",
			        Production = i,
			        Consumption = i,
			        Balance = 0,
			        SmartMeterSerialNumber = $"{i}"
		        };
			}

	        context.Prosumers.AddOrUpdate(x => x.Id, prosumers);
			*/
        }
	}
}
