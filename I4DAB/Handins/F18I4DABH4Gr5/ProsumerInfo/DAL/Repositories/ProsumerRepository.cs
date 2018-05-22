using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProsumerInfo.Models;

namespace ProsumerInfo.DAL.Repositories
{
	public class ProsumerRepository : Repository<Prosumer>, IProsumerRepository
	{
	    public ProsumerRepository(ProsumerInfoContet context) : base(context)
	    {

	    }
	}
}