using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class ZipDTO
    {
        public ZipDTO() { }

        public ZipDTO(Zip zip)
        {
            Id = zip.Id;
            Country = zip.Country;
            Town = zip.Town;
            ZipCode = zip.ZipCode;
        }

        public Zip ToZip()
        {
            return new Zip()
                {
                    Id = Id,
                    Country = Country,
                    Town = Town,
                    ZipCode = ZipCode
                };
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
    }
}