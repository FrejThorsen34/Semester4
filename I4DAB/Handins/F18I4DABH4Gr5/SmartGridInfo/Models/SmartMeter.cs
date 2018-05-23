using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SmartGridInfo.Models
{
	public class SmartMeter
	{
		[Key]
		public string SerialNumber { get; set; }
		public string ProsumerId { get; set; }
		public virtual ICollection<Connection> Connections { get; set; }
	}
}