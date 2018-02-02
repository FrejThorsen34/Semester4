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
            IPlayer winner = null;
            foreach (var IPlayer in _players)
            {
                var ntv = IPlayer.TotalValue();
                if (ntv > tv)
                {
                    tv = ntv;
                    winner = IPlayer;
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

            foreach (var IPlayer in _players)
            {
                _deck.DealCards(IPlayer, numberOfCards);
            }
        }
    }
}
