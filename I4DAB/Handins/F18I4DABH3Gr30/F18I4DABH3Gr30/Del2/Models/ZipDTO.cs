using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class ZipDTO
	{
		public ZipDTO(){}

		public ZipDTO(Zip zip)
		{
			Country = zip.Country;
			Town = zip.Town;
			Zipcode = zip.Zipcode;
		}
		
		public string Country { get; set; }
		public string Town { get; set; }
		public string Zipcode { get; set; }
	}

}