using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class PhoneNumber
	{
		public int Id { get; set; }
		public string PhoneType { get; set; }
		public uint Number { get; set; }
		public string Provider { get; set; }
	}
}
