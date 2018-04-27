using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public string PhoneType { get; set; }
        public string Number { get; set; }
        //Foreign Key
        public int PersonId { get; set; }
        //Navigation property
        public virtual Person Person { get; set; }
    }
}