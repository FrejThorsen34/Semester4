using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PersonKartotek.DAL.Repositories;
using PersonKartotek.Models;

namespace PersonKartotek.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
        public PersonKartotekContext Context { get; set; }
	    public IAddressRepository AddressRepository { get; set; }
	    public IPersonAddressRepository PersonAddressRepository { get; set; }
	    public IPersonRepository PersonRepository { get; set; }
	    public IPhoneNumberRepository PhoneNumberRepository { get; set; }
	    public IPrimaryAddressRepository PrimaryAddressRepository { get; set; }
	    public IZipRepository ZipRepository { get; set; }

	    public UnitOfWork(PersonKartotekContext context)
	    {
	        Context = context;
	        AddressRepository = new AddressRepository(context);
	        PersonAddressRepository = new PersonAddressRepository(context);
	        PersonRepository = new PersonRepository(context);
	        PhoneNumberRepository = new PhoneNumberRepository(context);
	        PrimaryAddressRepository = new PrimaryAddressRepository(context);
	        ZipRepository = new ZipRepository(context);
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