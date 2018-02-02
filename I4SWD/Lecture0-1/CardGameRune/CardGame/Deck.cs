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

		public Deck(Stack<ICard> cards)
		{
			_cards = cards;
		}

		public void Deal(IPlayer player, int numberOfCards)
		{
			if (_cards.Peek() == null) return;

			for (int i = 0; i > numberOfCards; i++)
			{
				player.DealCard(_cards.Pop());
			}
			
		}
	
	}
}
