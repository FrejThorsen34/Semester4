using System.Collections.Generic;

namespace TheObserverPattern
{
	public class StockHolding
	{
		private List<IPortfolio> _portfolios;
		private double _totalValue;
		private double _value;
		private uint _amount;
		private string _name;

		public StockHolding(Stock stock, uint amount)
		{
			stock.Attach(this);
			_name = stock.Name;
			_value = stock.Value;
			_amount = amount;
		}
		public void Update(Stock stock)
		{
			_value = stock.Value;
		}

		public void Attach(IPortfolio portfolio)
		{
			_portfolios.Add(portfolio);
		}

		public void Detach(IPortfolio portfolio)
		{
			_portfolios.Remove(portfolio);

		}

		public void Notify()
		{
			foreach (var p in _portfolios)
			{
				p.Update(this);
			}
		}

		

		public uint Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}
		public double Value
		{
			get { return _value; }
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