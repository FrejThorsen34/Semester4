using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(PersonKartotekContext context) : base(context)
        {

        }
    }
}