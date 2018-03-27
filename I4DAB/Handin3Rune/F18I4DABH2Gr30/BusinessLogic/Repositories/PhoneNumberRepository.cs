using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
	public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
	{
		public PhoneNumberRepository(ApplicationContext context):base(context){}
	}
}
