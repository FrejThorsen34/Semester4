using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalDB.Models
{
    public class AddressType : BaseModel
    {
        public int AddressId { get; set; }
        public string Type { get; set; }
        public virtual Address Address { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
