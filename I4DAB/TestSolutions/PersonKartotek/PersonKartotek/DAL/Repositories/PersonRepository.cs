using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonKartotekContext context) : base(context)
        {

        }
    }
}