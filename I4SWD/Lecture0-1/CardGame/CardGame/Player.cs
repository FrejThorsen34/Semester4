using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Player : IPlayer
    {
        public string Name { get; } = null;
        private List<ICard> _hand = new List<ICard>();

        public Player(string name)
        {
            Name = name;
        }

        public void ShowHand()
        {
            foreach (var ICard in _hand)
            {
                Console.WriteLine($"{Name} is holding a: {ICard.Suit} {ICard.Number}");
            }
        }

        public int TotalValue()
        {
            var totalValue = 0;
            foreach (var ICard in _hand)
            {
                totalValue = totalValue + ICard.Value;
            }
            // Console.WriteLine($"The total value of my hand is {totalValue}.");
            return totalValue;
        }

        public void DealCard(ICard card)
        {
            if(_hand.Count >= 7)
            {
                throw new InvalidOperationException("Maximum handsize in this game is 7!");
            }
            else
            _hand.Add(card);
        }
    }
}
