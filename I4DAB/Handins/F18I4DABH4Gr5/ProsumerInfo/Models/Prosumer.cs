using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerInfo.Models
{
	public class Prosumer
	{
		public string Id { get; set; }
		public string SmartMeterSerialNumber { get; set; }
		public virtual Identity Identity { get; set; }
		//Foreign Key
		public string IdentityId { get; set; }
		public double Production { get; set; }
		public double Consumption { get; set; }
		public double Balance { get; set; }
	}
}