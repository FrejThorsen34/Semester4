using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Game
    {
        public List<IPlayer> Players = new List<IPlayer>();
        private List<IPlayer> _winners = new List<IPlayer>();
        private Deck _deck = null;

        private bool _onGoing = false;

        public Game(Deck deck)
        {
            _deck = deck;
        }

        public List<IPlayer> Winner()
        {
            uint tv = 0;
            foreach (var player in Players)
            {
                var ntv = player.TotalValue();
                if (ntv > tv)
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
                throw new InvalidOperationException("Game has started, no new players!");
            else if(Players.Count == 10)
            {
                throw new InvalidOperationException("The maximum amount of players allowed is 10!");
            }
            else
                Players.Add(player);
        }

        public void DealAllPlayers(uint numberOfCards)
        {
            _onGoing = true;

            if ((Players.Count * numberOfCards) < _deck.Size)
            {
                foreach (var player in Players)
                {
                    _deck.DealCards(player, numberOfCards);
                }
            }
            else
                throw new InvalidOperationException("Not enough cards in deck!");
        }
    }
}
