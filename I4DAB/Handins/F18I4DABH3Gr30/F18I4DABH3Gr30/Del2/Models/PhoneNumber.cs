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
	public class PhoneNumber : BaseModel
	{
		[DataMember]
		[Required]
		public string PhoneType { get; set; }
		[DataMember]
		[Required]
		public string Number { get; set; }
		[DataMember]
		public string Provider { get; set; }
		[DataMember]
		public virtual Person Person { get; set; }
		//Foreign key
		[DataMember]
		public int PersonId { get; set; }
	}
}
