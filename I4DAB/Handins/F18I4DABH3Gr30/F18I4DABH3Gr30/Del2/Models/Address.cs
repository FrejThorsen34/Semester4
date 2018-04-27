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
	
	public class Address : BaseModel
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Address()
		{
			Persons = new HashSet<Person>();
			AddressTypes = new HashSet<AddressType>();
		}
		
		[Required]
		public string Street { get; set; }
		
		[Required]
		public string StreetNumber { get; set; }
		//Foreign key
		public int ZipId { get; set; }
		
		public virtual Zip Zip { get; set; }
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Person> Persons { get; set; }
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<AddressType> AddressTypes { get; set; }
	}
}
