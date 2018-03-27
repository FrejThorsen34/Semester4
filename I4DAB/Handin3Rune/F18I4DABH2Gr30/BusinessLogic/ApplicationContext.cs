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
			Configuration.LazyLoadingEnabled = false;
		}

		public virtual DbSet<Person> Persons { get; set; }
		public virtual DbSet<Address> Addresses { get; set; }
		public virtual DbSet<Zip> Zips { get; set; }
	}
}
