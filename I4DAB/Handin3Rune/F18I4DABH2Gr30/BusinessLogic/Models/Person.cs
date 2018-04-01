using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class Person
	{
		public Person()
		{
			SecondaryAddresses = new List<AddressType>();
			PhoneNumbers = new List<PhoneNumber>();
		}
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public string Email { get; set; }
		public virtual AddressType PrimaryAddress { get; set; }
		public virtual IList<AddressType> SecondaryAddresses { get; set; }
		public virtual IList<PhoneNumber> PhoneNumbers { get; set; }
	}
}
