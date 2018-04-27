using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class Zip
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
    }
}