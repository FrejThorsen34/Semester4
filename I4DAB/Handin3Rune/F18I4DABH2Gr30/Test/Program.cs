using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Models;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
			{
				Zip zip = new Zip();
				zip.State = "jylland";
				zip.Country = "DaneMArken";
				zip.Town = "Double A";
				zip.ZipCode = "9000";

				Address address = new Address();
				address.AddressType = "Home";
				address.ApartmentNumber = 1;
				address.Street = "Gaden";
				address.StreetNumber = 11;
				address.Zip = zip;

				PhoneNumber phone = new PhoneNumber();
				phone.Provider = "TDC";
				phone.PhoneType = "work";
				phone.Number = 12345678;
				
				Person person = new Person();
				person.PersonType = "BOSS!";
				person.FirstName = "Jens";
				person.MiddleName = "Peter";
				person.LastName = "Jensen";
				person.Email = "jens@jens.dk";
				person.Addresses.Add(address);
				person.PhoneNumbers.Add(phone);
				

				address.Persons.Add(person);

				unitOfWork.Persons.Add(person);
				unitOfWork.Complete();
			}
		}
	}
}
