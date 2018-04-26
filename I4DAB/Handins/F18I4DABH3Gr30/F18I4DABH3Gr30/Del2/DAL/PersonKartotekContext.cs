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
		
			public DbSet<PhoneNumber> PhoneNumbers { get; set; }
			public DbSet<Person> Persons { get; set; }
			public DbSet<PrimaryAddress> PrimaryAddresses { get; set; }
			public DbSet<AddressType> AddressTypes { get; set; }
			public DbSet<Address> Addresses { get; set; }
			public DbSet<Zip> Zips { get; set; }
	}
}