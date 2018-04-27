using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class AddressDTO
    {
        public AddressDTO() { }

        public AddressDTO(Address address)
        {
            Id = address.Id;
            Street = address.Street;
            StreetNumber = address.StreetNumber;
            Zip = new ZipDTO(address.Zip);

            //Vi får ikke langt people over i den liste i address korrekt, derfor er den tom
            //People = new List<string>();
            //foreach (Person p in address.People)
            //{
            //    People.Add(p.FirstName + " " + p.MiddleName + " " + p.LastName);
            //}

            PeopleAtAddress = new List<string>();
            foreach (PersonAddress pa in address.Addresses)
            {
                PeopleAtAddress.Add(pa.Person.FirstName + " " + pa.Person.LastName + ": " + pa.Type);                
            }
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        //public List<string> People { get; set; }
        public List<string> PeopleAtAddress { get; set; }
        public ZipDTO Zip { get; set; }
    }
}