using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Game
    {
        private List<IPlayer> _players = new List<IPlayer>();
        private List<IPlayer> _winners = new List<IPlayer>();
        private Deck _deck = null;

        private bool _onGoing = false;

        public Game(Deck deck)
        {
            _deck = deck;
        }

        public List<IPlayer> Winner()
        {
            var tv = 0;
            foreach (var IPlayer in _players)
            {
                var ntv = IPlayer.TotalValue();
                if (ntv > tv)
                {
                    tv = ntv;
                    _winners.Clear();
                    _winners.Add(IPlayer);
                }
                else if (ntv == tv)
                {
                    _winners.Add(IPlayer);
                }
            }
            return _winners;
        }

        public void AddPlayer(IPlayer player)
        {
            if (_onGoing == true)
                throw new InvalidOperationException("Game has started, no new players!");
            else if(_players.Count == 10)
            {
                throw new InvalidOperationException("The maximum amount of players allowed is 10!");
            }
            else
                _players.Add(player);
        }

        public void DealAllPlayers(int numberOfCards)
        {
            _onGoing = true;

            if ((_players.Count * numberOfCards) < _deck.Size)
            {
                foreach (var IPlayer in _players)
                {
                    _deck.DealCards(IPlayer, numberOfCards);
                }
            }
            else
                throw new InvalidOperationException("Not enough cards in deck!");
        }
    }
}
