using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TheObserverPattern
{
    public class Portfolio : IPortfolio
    {
	    private List<Stock> _stocks;
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
	    }

	    public void BuyStock(Stock stock)
	    {
			_stocks.Add(stock);
	    }

	    public void SellStock(Stock stock)
	    {
		    var name = stock.Name;

		    var index = _stocks.FindIndex(s => stock.Name == name);
			_stocks.RemoveAt(index);
	    }

	    public double TotalStockValue
	    {
		    get { return _totalStockValue; }
	    }
    }
}
