using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class RedCard : ICard
    {
        private string _suit;
        private int _number;
        private int _multiplier = 1;

        public RedCard(string suit, int number)
        {
            _suit = suit;
            _number = number;
        }

        public string Suit
        {
            get { return _suit; }
        }

        public int Number
        {
            get { return _number; }
        }

        public int Value
        {
            get { return _multiplier * _number; }
        }
    }
}
