using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public class Game
	{
		private List<IPlayer> _players = new List<IPlayer>();
		private Deck _deck = null;

		private bool _onGoing = false;

		public Game(Deck deck)
		{
			_deck = deck;
		}

		public IPlayer Winner()
		{
			var tv = 0;
			IPlayer winner = new Player("no winners ?");

			foreach (var p in _players)
			{
				var ntv = p.TotalValue();

				if(tv < ntv)
				{
					tv = ntv;
					winner = p;
				}

			}

			return winner;
		}

		public void AddPlayer(IPlayer player)
		{
			if (_onGoing == true)
			{
				throw new InvalidOperationException("Game has started, no new players");
			}
			else
			_players.Add(player);
		}

		public void DealAllPlayers(int numberOfCards)
		{
			_onGoing = true;

			foreach (var p in _players)
			{
				_deck.Deal(p,numberOfCards);
			}
		}

	}
}
