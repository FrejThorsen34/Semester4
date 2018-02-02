using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	

	public class Player : IPlayer
	{
		private List<ICard> _hand = new List<ICard>();
		public string Name { get; } = null;

		public List<ICard> ShowHand()
		{
			return _hand;
		}

		public int TotalValue()
		{
			int tv = 0;

			foreach (var c in _hand)
			{
				tv += c.Value;
			}

			return tv;
		}

		public void DealCard(ICard card)
		{
			_hand.Add(card);
		}
	}
}
