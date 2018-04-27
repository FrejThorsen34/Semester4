using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Del2.Models
{
	
	public class Person : BaseModel
	{

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Person()
		{
			SecondaryAddresses = new HashSet<AddressType>();
			PhoneNumbers = new HashSet<PhoneNumber>();
		}
		
		[Required]
		public string FirstName { get; set; }
		
		public string MiddleName { get; set; }
		
		[Required]
		public string LastName { get; set; }
		
		public string PersonType { get; set; }
		
		public string Email { get; set; }
		//Foreign key
		
		public int PrimaryAddressId { get; set; }
		
		public virtual PrimaryAddress PrimaryAddress { get; set; }
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<AddressType> SecondaryAddresses { get; set; }
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
	}
}
