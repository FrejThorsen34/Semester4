using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class AddressType
	{
		public string Type { get; set; }
		public Address Address { get; set; }
		public Person Person { get; set; }
	}
}
