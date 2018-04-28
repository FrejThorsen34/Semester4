using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PersonKartotekDD.Models
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
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        public string AddressType { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public virtual Zip Zip { get; set; }
    }

    public class PhoneNumber
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string Provider { get; set; }
        public virtual Person Person { get; set; }
    }

    public class Zip
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
    }
}