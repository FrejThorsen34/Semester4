using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Repositories;
using BusinessLogic.Interfaces;
namespace BusinessLogic
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationContext _context;

		public UnitOfWork(ApplicationContext context)
		{
			_context = context;
			Persons = new PersonRepository(_context);
			Addresses = new AddressRepository(_context);
			Zips = new ZipRepository(_context);
		}
		public IPersonRepository Persons { get; private set; }
		public IAddressRepository Addresses{ get; private set; }
		public IZipRepository Zips{ get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
