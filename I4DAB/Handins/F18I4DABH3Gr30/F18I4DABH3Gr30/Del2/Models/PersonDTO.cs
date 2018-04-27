using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PersonDTO
	{
		public PersonDTO()
		{ }

		public PersonDTO(Person person)
		{
			Id = person.Id;

			FirstName = person.FirstName;

			MiddleName = person.MiddleName;

			LastName = person.LastName;

			Email = person.Email;

			SecondaryAddresses = new List<AddressTypeDTO>();

			PhoneNumbers = new List<PhoneNumberDTO>();

			foreach (AddressType sa in person.SecondaryAddresses)
			{
				SecondaryAddresses.Add(new AddressTypeDTO(sa));
			}

			foreach (PhoneNumber pn in person.PhoneNumbers)
			{
				PhoneNumbers.Add(new PhoneNumberDTO(pn));
			}

			PrimaryAddress = new PrimaryAddressDTO(person.PrimaryAddress);

		}

		public Person ToPerson()
		{
			return new Person() { Id = Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, Email = Email, PrimaryAddress = PrimaryAddress.ToPrimaryAddress(), PrimaryAddressId = PrimaryAddress.Id, SecondaryAddresses = SecondaryAddresses.Select(pa => pa.ToAddressType()).ToList(), PhoneNumbers = PhoneNumbers.Select(pn => pn.ToPhoneNumber()).ToList() };
		}
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public string Email { get; set; }
		public PrimaryAddressDTO PrimaryAddress { get; set; }
		public List<AddressTypeDTO> SecondaryAddresses { get; set; }
		public List<PhoneNumberDTO> PhoneNumbers { get; set; }
	}
}