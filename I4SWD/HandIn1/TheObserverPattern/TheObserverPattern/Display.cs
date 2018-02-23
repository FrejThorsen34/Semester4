using System;
using System.Collections.Generic;
using System.Text;

namespace TheObserverPattern
{
    public class Display : IDisplay
    {
	    public void Update(Portfolio portfolio)
	    {
		    foreach (var p in portfolio._stockHoldings)
		    {
				Console.WriteLine($"Stock: {p.Name}");
			    Console.WriteLine($"Amount: {p.Amount}");
			    Console.WriteLine($"Value: {p.Value}");
			    Console.WriteLine($"Total Value: {p.TotalValue}");
			}
		}
    }
}
