using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class GreenCard : ICard
    {
        private string _suit = "Green";
        private int _number;
        private int _multiplier = 3;

        public GreenCard(int number)
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
