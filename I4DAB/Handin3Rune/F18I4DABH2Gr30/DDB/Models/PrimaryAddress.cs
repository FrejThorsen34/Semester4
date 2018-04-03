using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Models
{
	public class PrimaryAddress
	{
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public virtual Zip Zip { get; set; }
	}
}
