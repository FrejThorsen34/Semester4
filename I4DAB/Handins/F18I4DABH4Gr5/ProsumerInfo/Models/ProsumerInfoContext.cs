using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace ProsumerInfo.Models
{
	public class ProsumerInfoContext : DbContext
	{
		public ProsumerInfoContext() : base("name=DefaultConnection")
		{
			this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
		}

		public DbSet<ProsumerInfo.Models.Prosumer> Prosumers { get; set; }
		public DbSet<ProsumerInfo.Models.Identity> Identities { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Prosumer>()
				.HasRequired(p => p.Identity);
		}
	}
}