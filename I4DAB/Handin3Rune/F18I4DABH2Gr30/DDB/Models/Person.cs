using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDB.Models
{
	public class Person
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string PersonType { get; set; }
		public string Email { get; set; }
		public PrimaryAddress PrimaryAddress { get; set; }
		public AddressType[] SecondaryAddresses { get; set; }
		public PhoneNumber[] PhoneNumbers { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
