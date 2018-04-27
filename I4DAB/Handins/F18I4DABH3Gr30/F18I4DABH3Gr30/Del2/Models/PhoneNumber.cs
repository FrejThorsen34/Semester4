using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	public class PhoneNumber : BaseModel
	{
		[Required]
		public string PhoneType { get; set; }
		
		[Required]
		public string Number { get; set; }
		
		public string Provider { get; set; }
		
		public virtual Person Person { get; set; }
		//Foreign key
		public int PersonId { get; set; }
	}
}
