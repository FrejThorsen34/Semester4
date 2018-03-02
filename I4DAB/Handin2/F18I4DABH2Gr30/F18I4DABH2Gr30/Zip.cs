using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class ZIP
	{
		private string _country;
		private string _town;
		private string _state;
		private string _zipCode;

		public ZIP(string zipCode, string country, string state, string town)
		{
			_zipCode = zipCode;
			_country = country;
			_state = state;
			_town = town;
		}

		public string Country { get => _country;}
		public string Town { get => _town;}
		public string State { get => _state; }
		public string ZipCode { get => _zipCode;}

	}
}
