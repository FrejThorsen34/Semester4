using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public class Deck
	{
		private Stack<ICard> _cards = new Stack<ICard>();

		public void AddCards(int numberOfCards, int cardNumber, string suit)
		{
			for (int i = 0; i < numberOfCards; i++)
			{
				switch (suit)
				{
					case "Red":
						_cards.Push(new RedCard(cardNumber));
						break;
					case "Blue":
						_cards.Push(new BlueCard(cardNumber));
						break;
					case "Green":
						_cards.Push(new GreenCard(cardNumber));
						break;
					case "Yellow":
						_cards.Push(new YellowCard(cardNumber));
						break;
					default:
						throw new System.ArgumentException("Not a valid suit", suit);
				}
			}

		}

		public void Deal(Player player, int numberOfCards)
		{
			if (_cards.Peek() == null) return;

			for (int i = 0; i > numberOfCards; i++)
			{
				player.DealCard(_cards.Pop());
			}
			
		}
	
	}
}
