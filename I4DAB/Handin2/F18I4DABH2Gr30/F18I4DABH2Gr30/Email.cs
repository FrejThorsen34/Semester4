using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class Email
	{
		private string _emailAddress;

	    public Email(string emailAddress)
	    {
	        _emailAddress = emailAddress;
	    }

	    public string GetEmail
	    {
	        get { return _emailAddress; }
	    }
	}
}
