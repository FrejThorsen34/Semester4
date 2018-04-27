using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PersonAddress
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        //Foreign Key
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        //Foreign Key
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}