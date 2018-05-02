using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PersonKartotek.Models
{
	public class PersonKartotekContext : DbContext
	{
		public PersonKartotekContext() : base("name=DefaultConnection")
		{
			this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
		}

		public DbSet<PersonKartotek.Models.Person> People { get; set; }

		public DbSet<PersonKartotek.Models.PhoneNumber> PhoneNumbers { get; set; }

		public DbSet<PersonKartotek.Models.PrimaryAddress> PrimaryAddresses { get; set; }

		public DbSet<PersonKartotek.Models.Zip> Zips { get; set; }

		public DbSet<PersonKartotek.Models.Address> Addresses { get; set; }

		public DbSet<PersonKartotek.Models.PersonAddress> PersonAddresses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Address>()
				.HasMany(a => a.Addresses)
				.WithRequired(a => a.Address)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Address>()
				.HasRequired(a => a.Zip).WithMany(z => z.Addresses).WillCascadeOnDelete(false);

			modelBuilder.Entity<PrimaryAddress>()
				.HasMany(pa => pa.Persons)
				.WithRequired(p => p.PrimaryAddress)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PrimaryAddress>()
				.HasRequired(pa => pa.Zip)
				.WithMany(z => z.PrimaryAddresses)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zip>()
				.HasMany(z => z.PrimaryAddresses)
				.WithRequired(pa => pa.Zip)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Zip>()
				.HasMany(z => z.Addresses)
				.WithRequired(a => a.Zip)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Person>()
				.HasMany(p => p.PhoneNumbers)
				.WithRequired(p => p.Person)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Person>()
				.HasRequired(p => p.PrimaryAddress)
				.WithMany(pa => pa.Persons)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Person>()
				.HasMany(p => p.SecondaryAddresses)
				.WithRequired(sa => sa.Person)
				.WillCascadeOnDelete(false);
		}

	}
}
