using System.Collections.Generic;

namespace SmartGridInfo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using SmartGridInfo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartGridInfo.Models.SmartGridInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartGridInfo.Models.SmartGridInfoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

	        var smartMeter1 = new SmartGridInfo.Models.SmartMeter(){ ProsumerId="1", SerialNumber = "1", Connections = new List<Connection>()};
	        var smartMeter2 = new SmartGridInfo.Models.SmartMeter() { ProsumerId = "2", SerialNumber = "2", Connections = new List<Connection>()};
	        var smartMeter3 = new SmartGridInfo.Models.SmartMeter() { ProsumerId = "3", SerialNumber = "3", Connections = new List<Connection>() };

			var connection1 = new Connection()
	        {
		        Id = "1",
				SmartMeters = new List<Models.SmartMeter>() { smartMeter1, smartMeter2 },
				Distance = 20
	        };

	        var connection2 = new Connection()
	        {
		        Id = "2",
				SmartMeters = new List<Models.SmartMeter>() { smartMeter1, smartMeter3 },
				Distance = 30
	        };

	        var connection3 = new Connection()
	        {
		        Id = "3",
		        SmartMeters = new List<Models.SmartMeter>(){smartMeter2, smartMeter3},
		        Distance = 40
	        };

			smartMeter1.Connections.Add(connection1);
	        smartMeter1.Connections.Add(connection2);
			smartMeter2.Connections.Add(connection1);
	        smartMeter2.Connections.Add(connection3);
	        smartMeter3.Connections.Add(connection2);
	        smartMeter3.Connections.Add(connection3);

			context.Connections.AddOrUpdate(x => x.Id, connection1, connection2, connection3);
			context.SmartMeters.AddOrUpdate(x=> x.SerialNumber, smartMeter1, smartMeter2, smartMeter3);

        }
    }
}
