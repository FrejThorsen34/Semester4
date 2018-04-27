using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonKartotek.Models
{
    public class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            People = new HashSet<Person>();
            Addresses = new HashSet<PersonAddress>();
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        //Foreign Key
        public int ZipId { get; set; }
        public virtual Zip Zip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonAddress> Addresses { get; set; }
    }
}