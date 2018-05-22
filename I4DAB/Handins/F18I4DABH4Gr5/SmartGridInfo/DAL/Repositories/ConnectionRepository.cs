using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartGridInfo.Models;

namespace SmartGridInfo.DAL.Repositories
{
    public class ConnectionRepository : Repository<Connection>, IConnectionRepository
    {
        public ConnectionRepository(SmartGridInfoContext context) : base(context)
        {

        }
    }
}