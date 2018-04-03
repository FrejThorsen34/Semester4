using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class PrimaryAddress : BaseModel
	{
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public virtual Zip Zip { get; set; }
	}
}
