using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace TheObserverPattern
{
    public class Portfolio : IPortfolio
    {
	    public List<StockHolding> _stockHoldings = new List<StockHolding>();
	    private List<IDisplay> _displays= new List<IDisplay>();
	    private double _totalStockValue;

	    public void Update(StockHolding stockHolding)
	    {
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

		public void AddStock( StockHolding stockHolding)
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

	    //public void RemoveStock();

	    public double TotalStockValue
	    {
		    get { return _totalStockValue; }
		    set { _totalStockValue = value; Notify(); }
	    }
    }
}
