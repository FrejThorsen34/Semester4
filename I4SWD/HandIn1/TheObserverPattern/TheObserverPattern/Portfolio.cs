using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace TheObserverPattern
{
    public class Portfolio : IPortfolio
    {
	    public List<StockHolding> _stockHoldings;
	    private List<IDisplay> _displays;
	    private double _totalStockValue;

	    public void Update(StockHolding stockHolding)
	    {
		    var name = stockHolding.Name;
		    var index = _stockHoldings.FindIndex(sh => sh.Name == name);
		    _stockHoldings[index].Value = stockHolding.Value;
			TotalValueUpdate();
	    }
	    public void Attach(IDisplay display)
	    {
		    _displays.Add(display);
	    }

	    public void Detach(IDisplay display)
	    {
		    _displays.Remove(display);

	    }

	    public void Notify()
	    {
		    foreach (var d in _displays)
		    {
			    d.Update(this);
		    }
	    }

		public void AddStock( Stock stock, uint amount)
	    {
		    foreach (var sh in _stockHoldings)
		    {
			    if (sh.Name == stock.Name)
			    {
				    sh.Amount += amount;
					TotalValueUpdate();
					return;
			    }
		    }
		   _stockHoldings.Add(new StockHolding(stock, amount));
			TotalValueUpdate();
	    }

	    private void TotalValueUpdate()
	    {
		    double tv = 0;
		    foreach (var sh in _stockHoldings)
		    {
			    tv += sh.TotalValue;
		    }

		    _totalStockValue = tv;
		}

	    //public void RemoveStock();

	    public double TotalStockValue
	    {
		    get { return _totalStockValue; }
	    }
    }
}
