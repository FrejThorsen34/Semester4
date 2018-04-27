using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PhoneNumberDTO
    {
        public PhoneNumberDTO() { }

        public PhoneNumberDTO(PhoneNumber phoneNumber)
        {
            Id = phoneNumber.Id;
            Provider = phoneNumber.Provider;
            PhoneType = phoneNumber.PhoneType;
            Number = phoneNumber.Number;
            Person = phoneNumber.Person.FirstName + " " + phoneNumber.Person.MiddleName + " " + phoneNumber.Person.LastName;
        }

        public PhoneNumber ToPhoneNumber()
        {
            return new PhoneNumber()
            {
                Id = Id,
                Provider = Provider,
                PhoneType = PhoneType,
                Number = Number
            };
        }

        public int Id { get; set; }
        public string Provider { get; set; }
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string Person { get; set; }
    }
}