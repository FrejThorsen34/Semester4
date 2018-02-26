using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ObserverPatternAlternative;
using System.Timers;
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
//	Group 25									//
//	NE84070 - Nickolai Lundby Ernst				//
//	20105809 - Rune Aagaard Keena				//
//												//
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//


namespace ObserverPattern.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			Stock GoogleStock = new Stock("Google", 600.50);
			Stock VestasStock = new Stock("Vestas", 300);

			StockHolding TenGoogle = new StockHolding(GoogleStock, 10);
			StockHolding TwentyVestas = new StockHolding(VestasStock, 20);

			Portfolio MyPotfolio = new Portfolio();

			Display MyDisplay = new Display();

			MyPotfolio.Attach(MyDisplay);

			MyPotfolio.AddStock(TenGoogle);
			MyPotfolio.AddStock(TwentyVestas);

			Random myRandom = new Random();
			bool positive = true;
			double procent;

			while (true)
			{
				if (myRandom.Next(0, 2) == 1) positive = true;
				else positive = false;
				procent = myRandom.Next(1, 6);


				if (positive)
				{
					GoogleStock.Value += GoogleStock.Value * (procent / 100);
				}
				else
				{
					GoogleStock.Value -= GoogleStock.Value * (procent / 100);
				}

				if (myRandom.Next(0, 2) == 1) positive = true;
				else positive = false;
				procent = myRandom.Next(0, 6);

				if (positive)
				{
					VestasStock.Value += VestasStock.Value * (procent / 100);
				}
				else
				{
					VestasStock.Value -= VestasStock.Value * (procent / 100);
				}
				Thread.Sleep(3000);
			}
		}
	}
}
