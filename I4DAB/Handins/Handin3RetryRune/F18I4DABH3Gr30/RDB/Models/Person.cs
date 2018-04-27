using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RDB.Models
{
	public class Person
	{
		public int PersonId { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}