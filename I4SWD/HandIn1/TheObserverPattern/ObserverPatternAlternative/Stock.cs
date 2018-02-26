using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
//	Group 25									//
//	NE84070 - Nickolai Lundby Ernst				//
//	20105809 - Rune Aagaard Keena				//
//												//
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//

namespace ObserverPatternAlternative
{
	public class Stock : SubjectType<Stock>
	{
		private readonly string _name;
		private double _value;

		public Stock(string name, double value)
		{
			_value = value;
			_name = name;
		}

		public double GetValue()
		{
			return _value;
		}

		public string Name
		{
			get { return _name; }
		}

		public double Value
		{
			get { return _value; }
			set { _value = value; Notify(this); }
		}
	}
}
