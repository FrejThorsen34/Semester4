using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public class WeakPlayer : IPlayer
	{
		private List<ICard> _hand = new List<ICard>();
		public string Name { get; } = null;

		public WeakPlayer(string name)
		{
			Name = name+"(weak)";
		}
		public List<ICard> ShowHand()
		{
			return _hand;
		}

		public int TotalValue()
		{
			int tv = 0;

			foreach (var ICard in _hand)
			{
				tv = tv + ICard.Value;
			}

			return tv;
		}

		public void DealCard(ICard card)
		{
			_hand.Add(card);

			if (_hand.Count > 3)
			{
				Random random = new Random();
				_hand.RemoveAt((int)random.Next(1, 3));
			}
			
		}
	}
}
