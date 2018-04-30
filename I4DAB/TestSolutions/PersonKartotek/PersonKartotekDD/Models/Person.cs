using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PersonKartotekDD.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }
	    [JsonProperty(PropertyName = "FirstName", Required = Required.Always)]
		public string FirstName { get; set; }
	    [JsonProperty(PropertyName = "MiddleName")]
		public string MiddleName { get; set; }
	    [JsonProperty(PropertyName = "LastName", Required = Required.Always)]
		public string LastName { get; set; }
	    [JsonProperty(PropertyName = "PersonType", Required = Required.Always)]
		public string PersonType { get; set; }
	    [JsonProperty(PropertyName = "Email")]
		public string Email { get; set; }
	    [JsonProperty(PropertyName = "Addresses", Required = Required.AllowNull)]
		public Address[] Addresses { get; set; }
	    [JsonProperty(PropertyName = "PhoneNumbers", Required = Required.AllowNull)]
		public PhoneNumber[] PhoneNumbers { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Address
    {
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public string Id { get; set; }
	    [JsonProperty(PropertyName = "AddressType", Required = Required.Always)]
		public string AddressType { get; set; }
	    [JsonProperty(PropertyName = "Street", Required = Required.Always)]
		public string Street { get; set; }
	    [JsonProperty(PropertyName = "StreetNumber", Required = Required.Always)]
		public string StreetNumber { get; set; }
	    [JsonProperty(PropertyName = "Zip", Required = Required.Always)]
		public virtual Zip Zip { get; set; }
    }

    public class PhoneNumber
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }
	    [JsonProperty(PropertyName = "PhoneType", Required = Required.Always)]
		public string PhoneType { get; set; }
	    [JsonProperty(PropertyName = "Number", Required = Required.Always)]
		public string Number { get; set; }
	    [JsonProperty(PropertyName = "Provider")]
		public string Provider { get; set; }
    }

    public class Zip
    {
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }
	    [JsonProperty(PropertyName = "Country", Required = Required.Always)]
		public string Country { get; set; }
	    [JsonProperty(PropertyName = "Town", Required = Required.Always)]
		public string Town { get; set; }
	    [JsonProperty(PropertyName = "ZipCode", Required = Required.Always)]
		public string ZipCode { get; set; }
    }
}