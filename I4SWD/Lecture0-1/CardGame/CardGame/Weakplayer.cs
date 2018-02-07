using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class WeakPlayer : IPlayer
    {
        public string Name { get; } = null;
        private int Handsize = 3;
        Random myRand = new Random();
        private List<ICard> _hand = new List<ICard>();

        public WeakPlayer(string name)
        {
            Name = name;
        }

        public void ShowHand()
        {
            if (_hand.Count > 0)
            {
                foreach (var card in _hand)
                {
                    Console.WriteLine($"{Name} is holding a: {card.Suit} {card.Number}");
                }
            }
            else
                Console.WriteLine("My hand is empty!");
        }

        public uint TotalValue()
        {
            uint totalValue = 0;
            foreach (var card in _hand)
            {
                totalValue = totalValue + card.Value;
            }
            // Console.WriteLine($"The total value of my hand is {totalValue}.");
            return totalValue;
        }

        public void DealCard(ICard card)
        {
            if (_hand.Count >= Handsize)
            {
                int temp = myRand.Next(1, Handsize);
                _hand.RemoveAt(temp);
            }
            _hand.Add(card);
        }
    }
}
