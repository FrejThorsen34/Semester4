using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	
	public class Zip : BaseModel
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Zip()
		{
			Addresses = new HashSet<Address>();
		}
		
		[Required]
		public string Country { get; set; }
		
		[Required]
		public string Town { get; set; }
		[Required]
		
		public string Zipcode { get; set; }
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Address> Addresses { get; set; }
	}
}
