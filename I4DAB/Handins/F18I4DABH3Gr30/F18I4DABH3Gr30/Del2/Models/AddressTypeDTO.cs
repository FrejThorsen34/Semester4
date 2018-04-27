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
		public int Id { get; set; }
		public AddressDTO Address { get; set; }
		public PersonDTO Person { get; set; }
		public string Type { get; set; }
		
	}

}