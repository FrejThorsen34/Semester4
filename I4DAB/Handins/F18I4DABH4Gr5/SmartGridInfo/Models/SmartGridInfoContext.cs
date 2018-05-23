using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartGridInfo.Models
{
    public class SmartGridInfoContext : DbContext
    {
        public SmartGridInfoContext() : base("name=DefaultConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<SmartGridInfo.Models.SmartMeter> SmartMeters { get; set; }
        public DbSet<SmartGridInfo.Models.Connection> Connections { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SmartMeter>()
				.HasMany(c => c.Connections)
				.WithMany(sm => sm.SmartMeters);
		}
	}
}