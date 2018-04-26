using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PersonDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public string Email { get; set; }
		public int PrimaryAddressId { get; set; }
	}

	public class PersonDetailDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public string Email { get; set; }
		public int PrimaryAddressId { get; set; }
		public virtual PrimaryAddress PrimaryAddress { get; set; }
		public virtual ICollection<AddressTypeDTO> SecondaryAddresses { get; set; }
		public virtual ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }
	}
}