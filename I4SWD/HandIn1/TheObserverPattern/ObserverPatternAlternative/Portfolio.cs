using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternAlternative
{
	public class Portfolio : SubjectType<Portfolio>, IObserver<StockHolding>
	{
		private double _totalStockValue;
		public List<StockHolding> _stockHoldings = new List<StockHolding>();

		public void Update(StockHolding subjectType)
		{
			TotalValueUpdate();
		}
		public void AddStock(StockHolding stockHolding)
		{
			foreach (var sh in _stockHoldings)
			{
				if (sh.Name == stockHolding.Name)
				{
					sh.Amount += stockHolding.Amount;
					TotalValueUpdate();
					return;
				}
			}
			_stockHoldings.Add(stockHolding);
			stockHolding.Attach(this);
			TotalValueUpdate();
		}

		private void TotalValueUpdate()
		{
			double tv = 0;
			foreach (var sh in _stockHoldings)
			{
				tv += sh.TotalValue;
			}

			TotalStockValue = tv;
		}

		public double TotalStockValue
		{
			get { return _totalStockValue; }
			set { _totalStockValue = value; Notify(this); }
		}
	}
}
