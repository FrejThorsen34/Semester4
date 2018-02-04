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
		private Stack<ICard> _cards;

		public Deck(List<ICard> cards)
		{
			_cards = new Stack<ICard>(cards);
		}

		public void Deal(IPlayer player, int numberOfCards)
		{
			if (numberOfCards <= 0)
				throw new InvalidOperationException("Cannot deal less than one card");
			if (numberOfCards > 0)
			{
				for (int i = 0; i < numberOfCards; i++)
				{
					if (_cards.Count < 1)
					{
						Console.WriteLine("The Deck is empty!");
						return;
					}
						
					player.DealCard(_cards.Pop());
				}
			}
		}
	
	}
}
