using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SmartGridInfo.Models
{
	public class Connection
	{
		//needs id?

		public string SerialNumber1 { get; set; }
		public string SerialNumber2 { get; set; }
		public double Distance { get; set; }
	}
}