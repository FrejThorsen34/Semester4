using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PhoneNumberDTO
	{
		public int Id { get; set; }
		public string Number { get; set; }
		public int PersonId { get; set; }
	}

	public class PhoneNumberDetailDTO
	{
		public int Id { get; set; }
		public string PhoneType { get; set; }
		public string Number { get; set; }
		public string Provider { get; set; }
		public int PersonId { get; set; }
	}
}