using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDB.Models
{
	public class Address
	{
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public Zip Zip { get; set; }
	}
}
