using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SmartGridInfo.Models
{
	public class Connection
	{
		public string Id { get; set; }
		//Foreign Key
		//public string SerialNumber1 { get; set; }
		//Foreign Key
		//public string SerialNumber2 { get; set; }
		public virtual ICollection<SmartMeter> SmartMeters { get; set; }
		public double Distance { get; set; }
	}
}