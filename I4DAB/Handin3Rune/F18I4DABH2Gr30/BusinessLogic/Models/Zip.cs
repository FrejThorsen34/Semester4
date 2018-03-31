using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class Zip
	{
		public string Country { get; set; }
		public string Town { get; set; }
		public string State { get; set; }
		[Key]
		public string ZipCode { get; set; }
	}
}
