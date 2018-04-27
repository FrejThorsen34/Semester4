using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PersonKartotekContext : DbContext
    {
        public PersonKartotekContext() : base("name=PersonKartotekContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<PersonKartotek.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<PersonKartotek.Models.PhoneNumber> PhoneNumbers { get; set; }

        public System.Data.Entity.DbSet<PersonKartotek.Models.PrimaryAddress> PrimaryAddresses { get; set; }

        public System.Data.Entity.DbSet<PersonKartotek.Models.Zip> Zips { get; set; }

        public System.Data.Entity.DbSet<PersonKartotek.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<PersonKartotek.Models.PersonAddress> PersonAddresses { get; set; }
    }
}
