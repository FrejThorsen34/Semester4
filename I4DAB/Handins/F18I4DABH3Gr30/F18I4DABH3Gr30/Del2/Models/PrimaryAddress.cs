using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	[DataContract(IsReference = true)]
	public class PrimaryAddress : BaseModel
	{
		[DataMember]
		public string Street { get; set; }
		[DataMember]
		public string StreetNumber { get; set; }
		[DataMember]
		public virtual Zip Zip { get; set; }
	}
}
