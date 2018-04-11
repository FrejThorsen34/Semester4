using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RelationalDB.Models;

namespace RelationalDB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {

        }


        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PrimaryAddress> PrimaryAddresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Zip> Zips { get; set; }

    }
}
