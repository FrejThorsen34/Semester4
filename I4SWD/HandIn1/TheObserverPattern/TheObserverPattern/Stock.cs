using System;
using System.Collections.Generic;

namespace TheObserverPattern
{
	public class Stock
	{
		private List<StockHolding> _stockHoldings = new List<StockHolding>();
		public void Attach(StockHolding stockHolding)
		{
			_stockHoldings.Add(stockHolding);
		}

		public void Detach(StockHolding stockHolding)
		{
			_stockHoldings.Remove(stockHolding);

		}

		public void Notify()
		{
			foreach (var sh in _stockHoldings)
			{
				sh.Update(this);
			}
		}

		private readonly string _name;
		private double _value;

		public Stock(string name, double value)
		{
			_value = value;
			_name = name;
		}

		public string Name
		{
			get { return _name; }
		}

		public double Value
		{
			get { return _value; }
			set { _value = value; Notify();}
		}

	}

	//class GoogleStock : Stock
	//{
	//	private string _name = "Google";
	//	private double _value;

	//	GoogleStock(double value)
	//	{
	//		_value = value;
	//	}

	//	public string Name
	//	{
	//		get { return _name;}
	//	}

	//	public double Value
	//	{
	//		get { return _value;}
	//		set { _value = value; }
	//	}
	//}

	//class VestasStock : Stock
	//{
	//	private string _name = "Vestas";
	//	private double _value;

	//	VestasStock(double value)
	//	{
	//		_value = value;
	//	}

	//	public string Name
	//	{
	//		get { return _name; }
	//	}

	//	public double Value
	//	{
	//		get { return _value; }
	//		set { _value = value; }
	//	}
	//}
}
