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
	public class StockHolding : SubjectType<StockHolding>, IObserver<Stock>
	{

		private double _value;
		private uint _amount;
		private string _name;
		public StockHolding(Stock stock, uint amount)
		{
			_name = stock.Name;
			_value = stock.Value;
			_amount = amount;
			stock.Attach(this);
		}

		public void Update(Stock subject)
		{
			Value = subject.Value;
		}

		public uint Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}
		public double Value
		{
			get { return _value; }
			set { _value = value; Notify(this); }
		}

		public string Name
		{
			get { return _name; }
		}

		public double TotalValue
		{
			get { return _amount * _value; }
		}

	}
}
