using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
	public class AddressTypeRepository : Repository<AddressType>, IAddressTypeRepository
	{
		public AddressTypeRepository(ApplicationContext context) : base(context) { }
	}
}