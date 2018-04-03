using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDB.Models
{
	public class PhoneNumber
	{
		public string PhoneType { get; set; }
		public string Number { get; set; }
		public string Provider { get; set; }
	}
}
