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
		private List<ICard> _cards;

		public Deck(List<ICard> cards)
		{
			_cards = cards;
		}

		public void Deal(IPlayer player, int numberOfCards)
		{
			if (numberOfCards <= 0)
				throw new InvalidOperationException("Cannot deal less than one card");
			if (numberOfCards > 0)
			{
				Random random = new Random();
				for (int i = 0; i < numberOfCards; i++)
				{
					if (_cards.Count < 1)
					{
						Console.WriteLine("The Deck is empty!");
						return;
					}

					int randomnumber = random.Next(0, _cards.Count);
					player.DealCard(_cards[randomnumber]);
					_cards.RemoveAt(randomnumber);
				}
			}
		}
	
	}
}
