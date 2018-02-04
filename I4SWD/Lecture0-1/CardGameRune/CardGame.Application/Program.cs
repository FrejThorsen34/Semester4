using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Application
{
	class Program
	{
		static void Main(string[] args)
		{

			//Generate Deck
			List<ICard> myCards = new List<ICard>();

			Random random = new Random();

				for (int i = 1; i <= 25; i++)
				{
					int suit = (int)random.Next(1, 5);
					int number = (int)random.Next(1, 8);

					switch (suit)
					{
						case 1:
							var red = new RedCard(number);
							myCards.Add(red);
							break;
						case 2:
							var blue = new BlueCard(number);
							myCards.Add(blue);
							break;
						case 3:
							var green = new GreenCard(number);
							myCards.Add(green);
							break;
						case 4:
							var yellow = new YellowCard(number);
							myCards.Add(yellow);
							break;
						case 5:
							var gold = new GoldCard(number);
							myCards.Add(gold);
							break;
					default:
							throw new InvalidOperationException("Suit is undefined!");
					}
				}
		
			Deck myDeck = new Deck(myCards);
			IGame myGame = new GameLowWin(myDeck);

			IPlayer player1 = new Player("player1");
			IPlayer player2 = new Player("player2");
			IPlayer player3 = new Player("player3");
			IPlayer player4 = new WeakPlayer("player4");
			IPlayer player5 = new WeakPlayer("player5");

			myGame.AddPlayer(player1);
			myGame.AddPlayer(player2);
			myGame.AddPlayer(player3);
			myGame.AddPlayer(player4);
			myGame.AddPlayer(player5);

			myGame.DealAllPlayers(5);

			List<ICard> hand1 = player1.ShowHand();
			List<ICard> hand2 = player2.ShowHand();
			List<ICard> hand3 = player3.ShowHand();
			List<ICard> hand4 = player4.ShowHand();
			List<ICard> hand5 = player5.ShowHand();

			Console.WriteLine("Hand for PLayer 1: ");
		
			foreach (var card in hand1)
			{
				Console.WriteLine($"{card.Suit} {card.Number}");
			}

			Console.WriteLine("Hand for PLayer 2: ");

			foreach (var card in hand2)
			{
				Console.WriteLine($"{card.Suit} {card.Number}");
			}

			Console.WriteLine("Hand for PLayer 3: ");

			foreach (var card in hand3)
			{
				Console.WriteLine($"{card.Suit} {card.Number}");
			}

			Console.WriteLine("Hand for PLayer 4: ");

			foreach (var card in hand4)
			{
				Console.WriteLine($"{card.Suit} {card.Number}");
			}

			Console.WriteLine("Hand for PLayer 5: ");

			foreach (var card in hand5)
			{
				Console.WriteLine($"{card.Suit} {card.Number}");
			}

			Console.WriteLine("--------------------------------------------");

			foreach (var player in myGame.Players)
			{
				Console.WriteLine($"Total value of {player.Name}'s hand is {player.TotalValue()}.");
			}

			Console.WriteLine("The winner(s):");

			foreach (var winner in myGame.Winner())
			{
				Console.Write($"{winner.Name}, ");
			}
		}
	}
}
