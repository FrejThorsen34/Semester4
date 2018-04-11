using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
	public class Request
	{
		public Request(int value, string name)
		{
			Value = value;
			Name = name;
		}

		public int Value { get; private set; }
		public string Name { get; private set; }
	}
}
