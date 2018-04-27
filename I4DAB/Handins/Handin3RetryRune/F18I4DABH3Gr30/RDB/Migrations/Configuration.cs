using RDB.Models;

namespace RDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RDB.Models.PersonBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RDB.Models.PersonBookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

	        var TestPerson = new Person()
	        {
		        FirstName = "TestFornavn",
		        MiddleName = "TestMellemnavn",
		        LastName = "TestEfterbavn",
		        Email = "test@test.co"
	        };

			context.People.AddOrUpdate(TestPerson);
        }
    }
}
