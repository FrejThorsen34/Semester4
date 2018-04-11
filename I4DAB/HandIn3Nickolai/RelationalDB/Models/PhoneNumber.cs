using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalDB.Models
{
    public class PhoneNumber : BaseModel
    {
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string Provider { get; set; }
        public virtual Person Person { get; set; }
        public virtual int PersonId { get; set; }
    }
}
