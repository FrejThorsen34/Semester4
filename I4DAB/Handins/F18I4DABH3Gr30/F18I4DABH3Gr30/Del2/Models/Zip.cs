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
	public class Zip
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Zip()
		{
			Addresses = new HashSet<Address>();
		}
		[DataMember]
		[Required]
		public string Country { get; set; }
		[DataMember]
		[Required]
		public string Town { get; set; }
		[Key]
		[Required]
		[DataMember]
		public string Zipcode { get; set; }
		[DataMember]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Address> Addresses { get; set; }
	}
}
