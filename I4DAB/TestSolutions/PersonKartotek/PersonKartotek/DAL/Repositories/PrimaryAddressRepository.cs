using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public class PrimaryAddressRepository : Repository<PrimaryAddress>, IPrimaryAddressRepository
    {
        public PrimaryAddressRepository(PersonKartotekContext context) : base(context)
        {

        }
    }
}