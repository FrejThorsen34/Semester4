using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	[DataContract(IsReference = true)]
	public class Zip : BaseModel
	{
		[DataMember]
		public string Country { get; set; }
		[DataMember]
		public string Town { get; set; }
		[Key]
		[DataMember]
		public string Zipcode { get; set; }
		[DataMember]
		public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
	}
}
