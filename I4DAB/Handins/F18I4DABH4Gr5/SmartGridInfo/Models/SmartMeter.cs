using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SmartGridInfo.Models
{
	public class SmartMeter
	{
		//SerialNumber is id
		public string SerialNumber { get; set; }
		public string ProsumerId { get; set; }
		//Virtual??
		public Connection[] Connections { get; set; }
	}
}