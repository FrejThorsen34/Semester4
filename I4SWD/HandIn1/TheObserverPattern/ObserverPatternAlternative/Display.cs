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
	public class Display : IObserver<Portfolio>
	{
		public void Update(Portfolio subject)
		{
			List<StockHolding> stockHoldings = subject.StockHoldings;
			foreach (var sh in stockHoldings)
			{
				Console.WriteLine("---------------");
				Console.WriteLine($"Stock: {sh.Name}");
				Console.WriteLine($"Amount: {sh.Amount}");
				Console.WriteLine($"Value: {sh.Value:N2}");
				Console.WriteLine($"Total Value: {sh.TotalValue:N2}");
				Console.WriteLine("---------------");
			}
			Console.WriteLine($"Total Stock Value: {subject.TotalStockValue:N2}");
			Console.WriteLine("XXXXXXXXXXXXXXX");
		}
	}
}
