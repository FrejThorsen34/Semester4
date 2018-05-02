using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public class ZipRepository : Repository<Zip> , IZipRepository
    {
        public ZipRepository(PersonKartotekContext context) : base(context)
        {

        }
    }
}