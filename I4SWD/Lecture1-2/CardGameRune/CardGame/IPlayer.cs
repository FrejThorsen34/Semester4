using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public interface IPlayer
	{
		string Name { get; }

		List<ICard> ShowHand();

		int TotalValue();

		void DealCard(ICard card);
	}
}
