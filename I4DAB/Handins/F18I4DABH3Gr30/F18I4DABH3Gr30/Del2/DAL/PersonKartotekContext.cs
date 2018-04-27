using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Del2.Models;

namespace Del2.DAL
{
	public class PersonKartotekContext : DbContext
	{
			public PersonKartotekContext() : base("DefaultConnection"){}
		
			public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
			public virtual DbSet<Person> Persons { get; set; }
			public virtual DbSet<PrimaryAddress> PrimaryAddresses { get; set; }
			public virtual DbSet<AddressType> AddressTypes { get; set; }
			public virtual DbSet<Address> Addresses { get; set; }
			public virtual DbSet<Zip> Zips { get; set; }

			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				modelBuilder.Entity<Address>()
					.HasMany(e => e.AddressTypes)
					.WithRequired(e => e.Address)
					.WillCascadeOnDelete(false);
			}
	}
}