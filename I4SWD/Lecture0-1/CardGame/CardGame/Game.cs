using System;
using System.Collections.Generic;
using System.Text;

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
            IPlayer winner = new IPlayer("no winners?");
            foreach (var p in _players)
            {
                var ntv = p.TotalValue();
                if (ntv > tv)
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
                throw new InvalidOperationException("Game has started, no new players!");
            else
                _players.Add(player);
        }

        public void DealAllPlayers(int numberOfCards)
        {
            _onGoing = true;

            foreach (var p in _players)
            {
                _deck.DealCards(p, numberOfCards);
            }
        }
    }
}
