using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	public class PrimaryAddress : BaseModel
	{
		
		[Required]
		public string Street { get; set; }
		
		[Required]
		public string StreetNumber { get; set; }
		//Foreign key
		public int ZipId { get; set; }
		public virtual Zip Zip { get; set; }
	}
}
