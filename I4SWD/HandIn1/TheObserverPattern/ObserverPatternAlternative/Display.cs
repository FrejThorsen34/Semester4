using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternAlternative
{
	public class Display : IObserver<Portfolio>
	{
		public void Update(Portfolio subject)
		{
			foreach (var sh in subject._stockHoldings)
			{
				Console.WriteLine("---------------");
				Console.WriteLine($"Stock: {sh.Name}");
				Console.WriteLine($"Amount: {sh.Amount}");
				Console.WriteLine($"Value: {sh.Value}");
				Console.WriteLine($"Total Value: {sh.TotalValue}");
				Console.WriteLine("---------------");
			}
			Console.WriteLine($"Total Stock Value: {subject.TotalStockValue}");
			Console.WriteLine("XXXXXXXXXXXXXXX");
		}
	}
}
