using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PhoneNumberDTO
	{
		public PhoneNumberDTO(){}

		public PhoneNumberDTO(PhoneNumber phoneNumber)
		{
			Id = phoneNumber.Id;
			Number = phoneNumber.Number;
			Provider = phoneNumber.Provider;
			PhoneType = phoneNumber.PhoneType;
			Person = new PersonDTO(phoneNumber.Person);
		}
		public int Id { get; set; }
		public string Number { get; set; }
		public string Provider { get; set; }
		public string PhoneType { get; set; }
		public PersonDTO Person { get; set; }
	}

}