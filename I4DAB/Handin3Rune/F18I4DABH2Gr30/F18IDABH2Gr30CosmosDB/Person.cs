using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace F18IDABH2Gr30CosmosDB
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonType { get; set; }
        public string Email { get; set; }
        public Address[] Addresses { get; set; }
        public PhoneNumber[] PhoneNumbers { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Address
    {
		public string AddressType { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public ZIP ZIP { get; set; }
    }

    public class PhoneNumber
    {
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string Provider { get; set; }
    }

    public class ZIP
    {
        public string Country { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
    }
}
