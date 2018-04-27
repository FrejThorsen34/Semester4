using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Del2.Models;

namespace Del2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Del2.DAL.PersonKartotekContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Del2.DAL.PersonKartotekContext context)
        {
	        Zip zip1 = new Zip() {Id = 1, Country = "Denmark", Town = "Aarhus C", Zipcode = "8000"};
			PrimaryAddress primaryAddress2 = new PrimaryAddress() { Id = 2, Street = "Ny Munkegade", StreetNumber = "7C", ZipId = 1, Zip = zip1 };

			context.Zips.AddOrUpdate(x => x.Id,
				zip1,
				new Zip(){ Id = 2, Country = "Denmark", Town = "Aarhus N", Zipcode = "8200"},
				new Zip(){ Id = 3, Country = "Denmark", Town = "Odense C" , Zipcode = "5000"}
				);
			context.PrimaryAddresses.AddOrUpdate(x => x.Id,
				new PrimaryAddress(){ Id = 1, Street = "Volssmosegade", StreetNumber = "12A", ZipId = 3},
				primaryAddress2
				);
			context.Addresses.AddOrUpdate(x => x.Id,
				new Address(){ Id = 1, Street = "Strandvejen", StreetNumber = "1", ZipId = 2},
				new Address(){ Id = 2, Street = "Finlandsgade", StreetNumber = "17", ZipId = 1},
				new Address(){ Id = 3, Street = "Finlandsgade", StreetNumber = "11", ZipId = 1},
				new Address() { Id = 4, Street = "Søgaden", StreetNumber = "6", ZipId = 2}
				);
			context.Persons.AddOrUpdate(x => x.Id,
				new Person(){ Id = 1, FirstName = "Claus", MiddleName = "Von", LastName = "Trier", Email = "claus@vt.dk", PersonType = "Boss", PrimaryAddressId = 2, PrimaryAddress = primaryAddress2},
				new Person(){ Id = 2, FirstName = "Troels", MiddleName = "Den", LastName = "Lille", Email = "Troels@lille.dk", PersonType = "Employee", PrimaryAddressId = 1}
				);
	        context.AddressTypes.AddOrUpdate(x => x.Id,
		        new AddressType() { Id = 1, AddressId = 1, PersonId = 1, Type = "Summerhouse" },
		        new AddressType() { Id = 2, AddressId = 2, PersonId = 1, Type = "Work" },
		        new AddressType() { Id = 3, AddressId = 4, PersonId = 2, Type = "Summerhouse" },
		        new AddressType() { Id = 4, AddressId = 3, PersonId = 2, Type = "Work" }
	        );
			context.PhoneNumbers.AddOrUpdate(x => x.Id,
		        new PhoneNumber() { Id = 1, Number = "12345678", Provider = "Telia", PhoneType = "Work", PersonId = 1 },
		        new PhoneNumber() { Id = 2, Number = "87654321", PhoneType = "Private", Provider = "TDC", PersonId = 1 },
		        new PhoneNumber() { Id = 3, Number = "88888888", Provider = "Sonofon", PhoneType = "Work", PersonId = 2 },
		        new PhoneNumber() { Id = 4, Number = "44444444", Provider = "TDC", PhoneType = "Private", PersonId = 2 }
	        );
		}
    }
}
