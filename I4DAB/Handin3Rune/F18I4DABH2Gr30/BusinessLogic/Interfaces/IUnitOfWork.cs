using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public interface IUnitOfWork : IDisposable
    {
		IPersonRepository Persons { get; }
		IAddressRepository Addresses { get; }
		IZipRepository Zips { get; }
	    int Complete();
    }
}
