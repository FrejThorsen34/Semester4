using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
namespace BusinessLogic
{
	public class UnitOfWork : IDisposable
	{
		private readonly DbContext _context;

		public UnitOfWork(DbContext context)
		{
			_context = context;
			PhoneNumberRepo = new Repository<PhoneNumber>(_context);
			PersonRepo = new Repository<Person>(_context);
			PrimaryAddressRepo = new Repository<PrimaryAddress>(_context);
			AddressTypeRepo = new Repository<AddressType>(_context);
			AddressRepo = new Repository<Address>(_context);
			ZipRepo = new Repository<Zip>(_context);
		}

		public Repository<PhoneNumber> PhoneNumberRepo { get; set; }
		public Repository<Person> PersonRepo { get; set; }

		public Repository<PrimaryAddress> PrimaryAddressRepo { get; set; }
		public Repository<AddressType> AddressTypeRepo { get; set; }
		public Repository<Address> AddressRepo { get; set; }
		public Repository<Zip> ZipRepo { get; set; }
		public int Complete()
		{
			return _context.SaveChanges();
		}

		/*
		public async Task CompleteAsync()
		{
			await _context.SaveChangesAsync();
		}
		*/

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
