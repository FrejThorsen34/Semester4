using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class AddressTypeDTO
	{
		public int Id { get; set; }
		public int AddressId { get; set; }
		public int PersonId { get; set; }
		public string Type { get; set; }
		
	}
	public class AddressTypeDetailDTO
	{
		public int Id { get; set; }
		public int AddressId { get; set; }
		public int PersonId { get; set; }
		public string Type { get; set; }

	}
}