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
	[DataContract(IsReference = true)]
	public class Person : BaseModel
	{

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Person()
		{
			SecondaryAddresses = new HashSet<AddressType>();
			PhoneNumbers = new HashSet<PhoneNumber>();
		}
		[DataMember]
		[Required]
		public string FirstName { get; set; }
		[DataMember]
		public string MiddleName { get; set; }
		[DataMember]
		[Required]
		public string LastName { get; set; }
		[DataMember]
		public string PersonType { get; set; }
		[DataMember]
		public string Email { get; set; }
		//Foreign key
		[DataMember]
		public int PrimaryAddressId { get; set; }
		[DataMember]
		public virtual PrimaryAddress PrimaryAddress { get; set; }
		[DataMember]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<AddressType> SecondaryAddresses { get; set; }
		[DataMember]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
	}
}
