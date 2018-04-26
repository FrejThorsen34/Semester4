using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class ZipDTO
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }
		public string Zipcode { get; set; }
	}

	public class ZipDetailDTO
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }
		public string Zipcode { get; set; }
		public virtual ICollection<AddressDTO> Addresses { get; set; }
	}
}