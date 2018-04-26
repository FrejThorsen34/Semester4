using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Del2.Models;

namespace Del2.DAL
{
	public class UnitOfWork : IDisposable
	{
		private DbContext _context;

		public UnitOfWork(DbContext context)
		{
			_context = context;
		}

		private Repository<PhoneNumber> _phoneNumberRepo;
		private Repository<Person> _personRepo;
		private Repository<PrimaryAddress> _primaryAddressRepo;
		private Repository<AddressType> _addressTypeRepo;
		private Repository<Address> _addressRepo;
		private Repository<Zip> _zipRepo;

		public Repository<PhoneNumber> PhoneNumberRepo
		{
			get
			{
				if (_phoneNumberRepo == null)
				{
					_phoneNumberRepo = new Repository<PhoneNumber>(_context);
				}

				return _phoneNumberRepo;
			}
		}

		public Repository<Person> PersonRepo
		{
			get
			{
				if (_personRepo == null)
				{
					_personRepo = new Repository<Person>(_context);
				}

				return _personRepo;
			}
		}

		public Repository<PrimaryAddress> PrimaryAddressRepo
		{
			get
			{
				if (_primaryAddressRepo == null)
				{
					_primaryAddressRepo = new Repository<PrimaryAddress>(_context);
				}

				return _primaryAddressRepo;
			}
		}

		public Repository<AddressType> AddressTypeRepo
		{
			get
			{
				if (_addressTypeRepo == null)
				{
					_addressTypeRepo = new Repository<AddressType>(_context);
				}

				return _addressTypeRepo;
			}
		}

		public Repository<Address> AddressRepo
		{
			get
			{
				if (_addressRepo == null)
				{
					_addressRepo = new Repository<Address>(_context);
				}

				return _addressRepo;
			}
		}

		public Repository<Zip> ZipRepo
		{
			get
			{
				if (_zipRepo == null)
				{
					_zipRepo = new Repository<Zip>(_context);
				}

				return _zipRepo;
			}
		}

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