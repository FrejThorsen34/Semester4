using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalDB.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public virtual Zip Zip { get; set; }
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
        public virtual ICollection<AddressType> AddressTypes { get; set; } = new List<AddressType>();
    }
}
