using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class PrimaryAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        //Foreign Key
        public int PersonId { get; set; }
        //Navigation property
        public virtual Person Person { get; set; }
        //Foreign Key
        public int ZipId { get; set; }
        //Navigation property
        public virtual Zip Zip { get; set; }
    }
}