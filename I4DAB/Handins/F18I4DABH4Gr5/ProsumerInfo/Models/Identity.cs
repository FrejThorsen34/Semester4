using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProsumerInfo.Models
{
	public class Identity
	{
		public string Id { get; set; }
		public virtual Prosumer Prosumer { get; set; }
		public string ProsumerId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Type { get; set; }
	}
}