using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProsumerInfo.DAL.Repositories;

namespace ProsumerInfo.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		public ProsumerInfoContext Context { get; set; }
		public IProsumerRepository ProsumerRepository { get; set; }
		public IdentityRepository IdentityRepository { get; set; }

		public UnitOfWork(ProsumerInfoContext context)
		{
			Context = context;
			ProsumerRepository = new ProsumerRepository(context);
			IdentityRepository = new IdentityRepository(context);
		}
		public void Save()
		{
			Context.SaveChanges();
		}

		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
		}

	}
}