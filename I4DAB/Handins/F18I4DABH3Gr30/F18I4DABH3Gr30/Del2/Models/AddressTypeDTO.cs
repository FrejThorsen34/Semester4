using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class AddressTypeDTO
	{
		public AddressTypeDTO(){}

		public AddressTypeDTO(AddressType addressType)
		{
			Id = addressType.Id;
			Address = new AddressDTO(addressType.Address);
			Person = new PersonDTO(addressType.Person);
			Type = addressType.Type;
		}

		public AddressType ToAddressType()
		{
			return new AddressType()
			{
				Id = Id,
				Type = Type,
				Address = Address.ToAddress(),
				AddressId = Address.Id,
				Person = Person.ToPerson(),
				PersonId = Person.Id
			};
		}
		public int Id { get; set; }
		public AddressDTO Address { get; set; }
		public PersonDTO Person { get; set; }
		public string Type { get; set; }
		
	}

}