using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class Address
	{
		public Address()
		{
			Persons = new List<Person>();
		}
		public int Id { get; set; }
		public string Street { get; set; }
		public uint StreetNumber { get; set; }
		public Zip Zip { get; set; }
		public virtual IList<Person> Persons { get; set; }
	}
}
