using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerInfo.Models
{
	public class Prosumer
	{
		public string ProsumerID { get; set; }
		public string SmartMeterSerialNumber { get; set; }
		//Virtual?
		public Identity Identity { get; set; }
		public double Production { get; set; }
		public double Consumption { get; set; }
		public double Balance { get; set; }
	}
}