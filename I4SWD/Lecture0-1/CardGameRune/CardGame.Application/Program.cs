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
			Stack<ICard> myCards = new Stack<ICard>();

			for (int i = 0; i < 8; i++)
			{
				myCards.Push(new RedCard(i));
				myCards.Push(new BlueCard(i));
				myCards.Push(new GreenCard(i));
				myCards.Push(new YellowCard(i));
			}

			Deck myDeck = new Deck(myCards);

			Game myGame = new Game(myDeck);

			IPlayer player1 = new Player("player1");
			IPlayer player2 = new Player("player2");
			IPlayer player3 = new Player("player3");

			myGame.AddPlayer(player1);
			myGame.AddPlayer(player2);
			myGame.AddPlayer(player3);

			myGame.DealAllPlayers(5);

			List<ICard> hand1 = player1.ShowHand();
			List<ICard> hand2 = player2.ShowHand();
			List<ICard> hand3 = player3.ShowHand();
			
			Console.WriteLine("Hand for PLayer 1: ");
			int j = 1;
			foreach (var c in hand1)
			{
				Console.WriteLine($"Card:{j} is {c.Suit} {c.Number}");
				j++;
			}

			Console.WriteLine("Hand for PLayer 2: ");
			j = 1;
			foreach (var c in hand2)
			{
				Console.WriteLine($"Card:{j} is {c.Suit} {c.Number}");
				j++;
			}

			Console.WriteLine("Hand for PLayer 3: ");
			j = 1;
			foreach (var c in hand3)
			{
				Console.WriteLine($"Card:{j} is {c.Suit} {c.Number}");
				j++;
			}

			Console.WriteLine("--------------------------------------------");

			IPlayer winner = myGame.Winner();
			Console.WriteLine(winner.Name);
		}
	}
}
