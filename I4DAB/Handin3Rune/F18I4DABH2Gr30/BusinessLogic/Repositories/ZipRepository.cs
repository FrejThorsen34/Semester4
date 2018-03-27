using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;

namespace BusinessLogic.Repositories
{
	public class ZipRepository : Repository<Zip>, IZipRepository
	{
		public ZipRepository(ApplicationContext context) : base(context){}
	}
}
