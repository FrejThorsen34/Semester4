using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TheObserverPattern
{
    public class Portfolio : IPortfolio
    {
	    public List<Stock> _stocks;
	    private double _totalStockValue;

	    public void Update(Stock stock)
	    {
		    var name = stock.Name;
		    var value = stock.Value;

		    foreach (var s in _stocks)
		    {
			    if (s.Name == name)
			    {
				    s.Value = value;
			    }
		    }

		    double totalvalue = 0;
		    foreach (var s in _stocks)
		    {
			    totalvalue += s.Value;
		    }

		    _totalStockValue = totalvalue;
	    }

	    public void BuyStock(Stock stock)
	    {
		   _stocks.Add(stock);
		   _totalStockValue += stock.Value;
	    }

	    public void SellStock(Stock stock)
	    {
		    var name = stock.Name;
		    var index = _stocks.FindIndex(s => stock.Name == name);
		    if (index < 0)
		    {
			    throw new ArgumentOutOfRangeException("No stocks to sell");
		    }
			_stocks.RemoveAt(index);
		    _totalStockValue -= stock.Value;

		}

	    public double TotalStockValue
	    {
		    get { return _totalStockValue; }
	    }
    }
}
