using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PrimaryAddressDTO
	{
		public int Id { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string ZipCode { get; set; }
	}
	public class PrimaryAddressDetailDTO
	{
		public int Id { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string ZipCode { get; set; }
	}
}