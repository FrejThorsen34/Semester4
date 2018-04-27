using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class AddressDTO
	{
		public AddressDTO(){}

		public AddressDTO(Address address)
		{
			Id = address.Id;
			Street = address.Street;
			StreetNumber = address.StreetNumber;
			Zip = new ZipDTO(address.Zip);
			Persons = new List<PersonDTO>();
			AddressTypes = new List<AddressTypeDTO>();

			foreach (Person p in address.Persons)
			{
				Persons.Add(new PersonDTO(p));
			}

			foreach (AddressType a in address.AddressTypes)
			{
				AddressTypes.Add(new AddressTypeDTO(a));
			}

		}
		public int Id { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public ZipDTO Zip { get; set; }
		public List<PersonDTO> Persons { get; set; }
		public List<AddressTypeDTO> AddressTypes { get; set; }
	}

}