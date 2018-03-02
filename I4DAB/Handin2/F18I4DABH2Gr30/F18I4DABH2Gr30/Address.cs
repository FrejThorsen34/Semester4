using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	class Address
	{
		private string _addressType;
		private string _street;
		private uint _streetNo;
		private uint _apartmentNo;
		private ZIP _zip;

		public Address(string addressType, string street, uint streetNo, uint apartmentNo, ZIP zip)
		{
			_addressType = addressType;
			_street = street;
			_streetNo = streetNo;
			_apartmentNo = apartmentNo;

		}
	}
}
