using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalDB.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonType { get; set; }
        public string Email { get; set; }
        public virtual PrimaryAddress PrimaryAddress { get; set; }
        public virtual ICollection<AddressType> SecondaryAddresses { get; set; } = new List<AddressType>();
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    }
}
