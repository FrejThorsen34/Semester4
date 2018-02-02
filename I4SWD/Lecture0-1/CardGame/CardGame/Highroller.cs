﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Highroller : IPlayer
    {
        public string Name { get; } = null;
        private List<ICard> _hand = new List<ICard>();

        public Highroller(string name)
        {
            Name = name;
        }
        public string Name
        {
            get { return _name; }
        }

        public void ShowHand()
        {
            for (int i = 0; i <= _hand.Count; i++)
            {
                var number = _hand.[i].Number;
                var suit = _hand.[i].Suit;
                Console.WriteLine($"I am holding a {suit} {number}");
            }
        }

        public void TotalValue()
        {
            var totalValue = 0;
            for (int i = 0; i <= _hand.Count; i++)
            {
                totalValue = +_hand.[i].Value;
            }
            Console.WriteLine($"The total value of my hand is {totalValue}.");
        }

        public void DealCard(ICard card)
        {
            _hand.Add(card);
        }
    }
}
