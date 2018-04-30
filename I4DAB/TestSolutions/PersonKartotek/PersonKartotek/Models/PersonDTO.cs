using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PersonDTO
    {
        public PersonDTO() { }

        public PersonDTO(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            Email = person.Email;
			PrimaryAddress = new PrimaryAddressDTO(person.PrimaryAddress);
            PhoneNumbers = new List<PhoneNumberDTO>();
            foreach (PhoneNumber pn in person.PhoneNumbers)
            {
                PhoneNumbers.Add(new PhoneNumberDTO(pn));
            }

            SecondaryAddresses = new List<PersonAddressDTO>();
            foreach (PersonAddress pa in person.SecondaryAddresses)
            {
                SecondaryAddresses.Add(new PersonAddressDTO(pa));
            }
        }

        public Person ToPerson()
        {
            return new Person()
            {
                Id = Id,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Email = Email,
                PhoneNumbers = PhoneNumbers.Select(pn => pn.ToPhoneNumber()).ToList()
            };
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
		public PrimaryAddressDTO PrimaryAddress { get; set; }
        public List<PhoneNumberDTO> PhoneNumbers { get; set; }
        public List<PersonAddressDTO> SecondaryAddresses { get; set; }
    }
}