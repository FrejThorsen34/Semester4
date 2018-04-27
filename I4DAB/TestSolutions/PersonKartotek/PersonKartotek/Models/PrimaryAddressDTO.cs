using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PrimaryAddressDTO
    {
        public PrimaryAddressDTO() { }

        public PrimaryAddressDTO(PrimaryAddress primaryAddress)
        {
            Id = primaryAddress.Id;
            Street = primaryAddress.Street;
            StreetNumber = primaryAddress.StreetNumber;
            Person = new PersonDTO(primaryAddress.Person);
            Zip = new ZipDTO(primaryAddress.Zip);
        }

        public PrimaryAddress ToPrimaryAddress()
        {
            return new PrimaryAddress()
            {
                Id = Id,
                Street = Street,
                StreetNumber = StreetNumber,
                Person = Person.ToPerson(),
                Zip = Zip.ToZip()
            };
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public PersonDTO Person { get; set; }
        public ZipDTO Zip { get; set; }
    }
}