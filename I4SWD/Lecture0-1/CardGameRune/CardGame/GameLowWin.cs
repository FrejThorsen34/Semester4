using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public class GameLowWin : IGame
	{
		private List<IPlayer> _players = new List<IPlayer>();
		private List<IPlayer> _winners = new List<IPlayer>();
		private Deck _deck = null;
		private bool _onGoing = false;

		public GameLowWin(Deck deck)
		{
			_deck = deck;
		}

		public List<IPlayer> Players
		{
			get { return _players; }
		}

		public List<IPlayer> Winner()
		{

			var tv = Int32.MaxValue;

			foreach (var player in _players)
			{
				var ntv = player.TotalValue();

				if (ntv < tv)
				{
					tv = ntv;
					_winners.Clear();
					_winners.Add(player);
				}
				else if (ntv == tv)
				{
					_winners.Add(player);
				}
			}

			return _winners;
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
				_deck.Deal(p, numberOfCards);
			}
		}
	}
}
