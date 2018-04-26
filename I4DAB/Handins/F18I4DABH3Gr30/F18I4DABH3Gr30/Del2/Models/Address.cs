using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Del2.Models;

namespace Del2.Models
{
	[DataContract(IsReference = true)]
	public class Address : BaseModel
	{
		[DataMember]
		public string Street { get; set; }
		[DataMember]
		public string StreetNumber { get; set; }
		[DataMember]
		public virtual Zip Zip { get; set; }
		[DataMember]
		public virtual ICollection<Person> Persons { get; set; } = new List<Person>();
		[DataMember]
		public virtual ICollection<AddressType> AddressTypes { get; set; } = new List<AddressType>();
	}
}
