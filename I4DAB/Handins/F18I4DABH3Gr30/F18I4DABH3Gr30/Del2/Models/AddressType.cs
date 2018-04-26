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
	public class AddressType : BaseModel
	{
		//Foreign key
		[DataMember]
		public int AddressId { get; set; }
		[DataMember]
		public string Type { get; set; }
		[DataMember]
		public virtual Address Address { get; set; }
		[DataMember]
		public virtual Person Person { get; set; }
		//Foreign key
		[DataMember]
		public int PersonId { get; set; }
	}
}