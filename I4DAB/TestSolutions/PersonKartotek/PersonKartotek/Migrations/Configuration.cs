namespace PersonKartotek.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PersonKartotek.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonKartotek.Models.PersonKartotekContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonKartotek.Models.PersonKartotekContext context)
        {
            Zip Aarhus = new Zip() { Id = 1, Country = "Denmark", Town = "Aarhus", ZipCode = "8000" };
            Zip Odense = new Zip() { Id = 2, Country = "Denmark", Town = "Odense", ZipCode = "5000" };
            Zip Esbjerg = new Zip() { Id = 3, Country = "Denmark", Town = "Esbjerg", ZipCode = "6700" };
            Zip Grenaa = new Zip(){ Id = 4, Country = "Denmark", Town = "Grenaa", ZipCode = "8500"};
            context.Zips.AddOrUpdate(x => x.Id,
                Aarhus, Odense, Esbjerg, Grenaa
                );
			PrimaryAddress HjemmeHosKlaus = new PrimaryAddress(){ Id = 1, Street = "Ny Munkegade", StreetNumber = "1A", /*PersonId = 1, Person = Klaus,*/ ZipId = 1, Zip = Aarhus};
            PrimaryAddress HjemmeHosTroels = new PrimaryAddress() { Id = 2, Street = "Vestregade", StreetNumber = "7", /*PersonId = 2, Person = Troels,*/ ZipId = 2, Zip = Odense};
            PrimaryAddress HjemmeHosEmil = new PrimaryAddress() { Id = 3, Street = "Kirkegade", StreetNumber = "12B", /*PersonId = 3, Person = Emil,*/ ZipId = 3, Zip = Esbjerg};
            context.PrimaryAddresses.AddOrUpdate(x => x.Id,
                HjemmeHosKlaus, HjemmeHosTroels, HjemmeHosEmil
                );
	        Person Klaus = new Person() { Id = 1, FirstName = "Klaus", MiddleName = "Stormester", LastName = "Bossen", Email = "Klaus@Bossen.dk", PrimaryAddress = HjemmeHosKlaus, PrimaryAddressId = 1};
	        Person Troels = new Person() { Id = 2, FirstName = "Troels", MiddleName = "Slaven", LastName = "Medarbejdersen", Email = "Troels@Medarbejdersen.dk", PrimaryAddress = HjemmeHosTroels, PrimaryAddressId = 2};
	        Person Emil = new Person() { Id = 3, FirstName = "Emil", MiddleName = "Huhr", LastName = "Jensen", Email = "Emil@Jensen.dk", PrimaryAddress = HjemmeHosEmil, PrimaryAddressId = 3};
	        context.People.AddOrUpdate(x => x.Id,
		        Klaus, Troels, Emil
	        );
			PhoneNumber TlfKlaus = new PhoneNumber(){ Id = 1, Number = "88888888", Provider = "TDC", PhoneType = "Private", PersonId = 1, Person = Klaus};
            PhoneNumber TlfTroels = new PhoneNumber() { Id = 2, Number = "22222222", Provider = "Telia", PhoneType = "Private", PersonId = 2, Person = Troels};
            PhoneNumber TlfEmil = new PhoneNumber() { Id = 3, Number = "44444444", Provider = "Sonofon", PhoneType = "Private", PersonId = 3, Person = Emil};
            PhoneNumber TlfKlausWork = new PhoneNumber() { Id = 4, Number = "99999999", Provider = "TDC", PhoneType = "Work", PersonId = 1, Person = Klaus };
            PhoneNumber TlfTroelsWork = new PhoneNumber() { Id = 5, Number = "33333333", Provider = "Telia", PhoneType = "Work", PersonId = 2, Person = Troels };
            PhoneNumber TlfEmilWork = new PhoneNumber() { Id = 6, Number = "55555555", Provider = "Sonofon", PhoneType = "Work", PersonId = 3, Person = Emil };
            context.PhoneNumbers.AddOrUpdate(x => x.Id,
                TlfKlaus, TlfTroels, TlfEmil, TlfKlausWork, TlfTroelsWork, TlfEmilWork
                );
            Address Finlandsgade = new Address(){ Id = 1, Street = "Finlandsgade" , StreetNumber = "17", Zip = Aarhus, ZipId = 1};
            Address GrenaaStrandvej = new Address(){ Id = 2, Street = "Strandvejen", StreetNumber = "22", Zip = Grenaa, ZipId = 4};
            Address GrenaaByvej = new Address(){ Id = 3, Street = "Bygaden", StreetNumber = "17A", Zip = Grenaa, ZipId = 4};
            context.Addresses.AddOrUpdate(x => x.Id,
                Finlandsgade, GrenaaStrandvej, GrenaaByvej
                );
            PersonAddress ArbejdeK = new PersonAddress(){ Id = 1, Person = Klaus, PersonId = 1, Address = Finlandsgade, AddressId = 1, Type = "Work"};
            PersonAddress SommerhusK = new PersonAddress(){ Id = 2, Person = Klaus, PersonId = 1, Address = GrenaaStrandvej, AddressId = 2, Type = "Vacation"};
            PersonAddress ArbejdeT = new PersonAddress(){ Id = 3, Person = Troels, PersonId = 2, Address = Finlandsgade, AddressId = 1, Type = "Work"};
            PersonAddress ArbejdeE = new PersonAddress(){ Id = 4, Person = Emil, PersonId = 3, Address = Finlandsgade, AddressId = 1, Type = "Work"};
            PersonAddress SommerhusE = new PersonAddress(){ Id = 5, Person = Emil, PersonId = 3, Address = GrenaaByvej, AddressId = 3, Type = "Vacation"};
            context.PersonAddresses.AddOrUpdate(x => x.Id,
                ArbejdeK, SommerhusK, ArbejdeT, ArbejdeE, SommerhusE
                );
        }
    }
}
