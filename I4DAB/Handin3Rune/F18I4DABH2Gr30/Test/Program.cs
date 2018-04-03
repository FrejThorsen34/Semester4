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
				//Read operations
				var phones = unitOfWork.PhoneNumberRepo.GetAll();
				var persons = unitOfWork.PersonRepo.GetAll();
				var primaryAddresses = unitOfWork.PrimaryAddressRepo.GetAll();
				var addresstypes = unitOfWork.AddressTypeRepo.GetAll();
				var addresses = unitOfWork.AddressRepo.GetAll();
				var zips = unitOfWork.ZipRepo.GetAll();
				//Delete operations
				unitOfWork.ZipRepo.RemoveRange(zips);
				unitOfWork.AddressTypeRepo.RemoveRange(addresstypes);
				unitOfWork.AddressRepo.RemoveRange(addresses);
				unitOfWork.PhoneNumberRepo.RemoveRange(phones);
				unitOfWork.PrimaryAddressRepo.RemoveRange(primaryAddresses);
				unitOfWork.PersonRepo.RemoveRange(persons);
				unitOfWork.Complete();

				var zip = new Zip()
				{
					Country = "Denmark",
					Zipcode = "8000",
					Town = "Aarhus C"
				};


				Person person = new Person
				{
					FirstName = "Jens",
					MiddleName = "Kjeld",
					LastName = "Larsen",
					Email = "JKL@minmail.dk",
					PersonType = "co-worker",
					PhoneNumbers = new List<PhoneNumber>()
					{
						new PhoneNumber()
						{
							Number = "12345678",
							PhoneType = "Home",
							Provider = "TDC"
						},
						new PhoneNumber()
						{
							Number = "87654321",
							PhoneType = "Work",
							Provider = "Telia"
						}
					},
					PrimaryAddress = new PrimaryAddress
					{
						Street = "Ringgaden",
						StreetNumber = "154A",
						Zip = zip
					}
				};

				var addresshome = new Address()
				{
					StreetNumber = "11B",
					Street = "Vejen",
					Zip = zip
				};


				var HomeAddressType = new AddressType()
				{
					Type = "Home",
					Address = addresshome,
					Person = person

				};

				var WorkAddressType = new AddressType
				{
					Type = "Work",
					Address = new Address
					{
						StreetNumber = "89E",
						Street = "Arbejdsvej",
						Zip = zip
					},
					Person = person
				};

				//create operations
				person.SecondaryAddresses.Add(HomeAddressType);
				person.SecondaryAddresses.Add(WorkAddressType);
				unitOfWork.PersonRepo.Add(person);
				unitOfWork.Complete();

				//Read operation
				person = unitOfWork.PersonRepo.Get(person.Id);
				person.FirstName = "Mark";
				person.PhoneNumbers.Add(new PhoneNumber(){Number = "5655665",Provider = "Telia", PhoneType = "Mobile"});
				//Update operation
				unitOfWork.PersonRepo.Update(person.Id,person);
				unitOfWork.Complete();
			}
		}
	}
}
