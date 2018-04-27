using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	
	public class AddressType : BaseModel
	{
		//Foreign key
		public int AddressId { get; set; }
		
		[Required]
		public string Type { get; set; }
		
		public virtual Address Address { get; set; }
		
		public virtual Person Person { get; set; }
		//Foreign key
		public int PersonId { get; set; }
	}
}