using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(PersonKartotekContext context) : base(context)
        {

        }
    }
}