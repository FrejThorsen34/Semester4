using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class Person
	{
		private string _firstName;
	    private string _middleName;
		private string _lastName;

		private int _personID;
		private string _personType;

		private List<Address> _addresses;
		private List<PhoneNumber> _phoneNumbers;
		private Email _email;

	    public Person(string firstName, string middleName, string lastName, int personId, string personType)
	    {
	        _firstName = firstName;
	        _middleName = middleName;
	        _lastName = lastName;
	        _personID = personId;
	        _personType = personType;
            _addresses = new List<Address>();
            _phoneNumbers = new List<PhoneNumber>();
	    }

        #region Properties
        public string FirstName
	    {
	        get { return _firstName; }
	    }

	    public string MiddleName
	    {
	        get { return _middleName; }
	    }

	    public string LastName
	    {
	        get { return _lastName; }
	    }

	    public int PersonId
	    {
	        get { return _personID; }
	    }

	    public string PersonType
	    {
	        get { return _personType; }
	    }

        #endregion

        public void SetAddress(Address address)
	    {
	        _addresses.Add(address);
	    }

	    public List<Address> GetAddress()
	    {
	        return _addresses;
	    }

	    public void SetPhoneNumber(PhoneNumber phoneNumber)
	    {
            _phoneNumbers.Add(phoneNumber);
	    }

	    public List<PhoneNumber> GetPhoneNumbers()
	    {
	        return _phoneNumbers;
	    }

	    public void SetEmail(Email email)
	    {
	        _email = email;
	    }

	    public Email GetEmail()
	    {
	        return _email;
	    }
	}
}
