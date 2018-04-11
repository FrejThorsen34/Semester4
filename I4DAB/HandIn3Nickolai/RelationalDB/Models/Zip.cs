using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalDB.Models
{
    public class Zip : BaseModel
    {
        public string Country { get; set; }
        public string Town { get; set; }
        [Key]
        public string Zipcode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
