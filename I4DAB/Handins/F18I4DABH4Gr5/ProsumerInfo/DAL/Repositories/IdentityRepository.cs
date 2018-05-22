using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProsumerInfo.Models;

namespace ProsumerInfo.DAL.Repositories
{
	public class IdentityRepository : Repository<Identity> , IIdentityRepository
	{
	    public IdentityRepository(ProsumerInfoContext context) : base(context)
	    {

	    }
	}
}