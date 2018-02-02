using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class RedCard : ICard
    {
        private string _suit = "Red";
        private int _number;
        private int _multiplier = 1;

        public RedCard(int number)
        {
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
