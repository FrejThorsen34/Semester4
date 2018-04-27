using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PersonAddressDTO
    {
        public PersonAddressDTO() { }

        public PersonAddressDTO(PersonAddress personAddress)
        {
            Id = personAddress.Id;
            Type = personAddress.Type;
            Person = personAddress.Person.FirstName + " " + personAddress.Person.MiddleName + " " + personAddress.Person.LastName;
            Address = new AddressDTO(personAddress.Address);
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Person { get; set; }
        public AddressDTO Address { get; set; }
    }
}