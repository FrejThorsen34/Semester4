using System.Security.Cryptography.X509Certificates;
using Del2.Models;

namespace Del2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Del2.DAL.PersonKartotekContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Del2.DAL.PersonKartotekContext context)
        {
			//Test
	        context.Persons.Add(new Person() {FirstName = "TestMan", MiddleName = "Test", LastName = "Testersen"});
        }
    }
}
