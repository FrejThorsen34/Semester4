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
			Id = zip.Id;
			Country = zip.Country;
			Town = zip.Town;
			Zipcode = zip.Zipcode;
		}

		public Zip ToZip()
		{
			return new Zip() {Id = Id, Town = Town, Country = Country, Zipcode = Zipcode};
		}

		public int Id { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }
		public string Zipcode { get; set; }
	}

}