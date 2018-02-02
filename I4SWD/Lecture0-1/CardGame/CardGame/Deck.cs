using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        private ICard _card = null;

        public Deck(ICard card)
        {
            _card = card;
        }
        public void DealCards(IPlayer player, int number)
        {

        }
    }
}
