using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class Address
	{
		private string _addressType;
		private string _street;
		private uint _streetNo;
		private uint _apartmentNo;
		private ZIP _zip;
		private List<Person> _persons = new List<Person>();

		public Address(string addressType, string street, uint streetNo, uint apartmentNo, ZIP zip)
		{
			_addressType = addressType;
			_street = street;
			_streetNo = streetNo;
			_apartmentNo = apartmentNo;
		    int i = ZIPList.LookUp(zip);
		    _zip = ZIPList._zips[i];
		}

        #region Properties

        public string GetAddressType
	    {
	        get { return _addressType; }
	    }

	    public string GetStreet
	    {
	        get { return _street; }
	    }

	    public uint GetStreetNo
	    {
	        get { return _streetNo; }
	    }

	    public uint GetApartmentNo
	    {
	        get { return _apartmentNo; }
	    }

	    public ZIP GetZIP
	    {
	        get { return _zip; }
	    }
		#endregion

		#region Commands

		public void AddPerson(Person person)
		{
			bool isThere = _persons.Contains(person);
			if (!isThere)
			{
				_persons.Add(person);
			}
			else
			{
				return;
			}
		}

		public List<Person> LookUpPersons()
		{
			return _persons;
		}

		#endregion
	}
}
