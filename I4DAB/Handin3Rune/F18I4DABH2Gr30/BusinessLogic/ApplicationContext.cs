using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusinessLogic.Models;

namespace BusinessLogic
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base("DefaultConnection")
		{
			//Configuration.LazyLoadingEnabled = true;
		}

		
		public DbSet<PhoneNumber> PhoneNumbers { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<PrimaryAddress> PrimaryAddresses { get; set; }
		public DbSet<AddressType> AddressTypes { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Zip> Zips { get; set; }

	}
}
