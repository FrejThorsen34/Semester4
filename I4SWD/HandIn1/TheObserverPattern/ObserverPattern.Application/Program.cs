using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheObserverPattern;

namespace ObserverPattern.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			Stock GoogleStock = new Stock("Google", 600.50);
			Stock VestasStock = new Stock("Vestas",300);

			StockHolding TenGoogle = new StockHolding(GoogleStock, 10);
			StockHolding TwentyVestas = new StockHolding(VestasStock, 20);

			Portfolio MyPotfolio = new Portfolio();

			Display MyDisplay = new Display();

			MyPotfolio.Attach(MyDisplay);

			MyPotfolio.AddStock(TenGoogle);
			MyPotfolio.AddStock(TwentyVestas);

			GoogleStock.Value = 700;

			Console.ReadLine();
		}
	}
}
