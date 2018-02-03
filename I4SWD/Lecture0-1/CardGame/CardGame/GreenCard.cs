using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class GreenCard : ICard
    {
        private string _suit = "Green";
        private uint _number;
        private uint _multiplier = 3;

        public GreenCard(uint number)
        {
            _number = number;
        }

        public string Suit
        {
            get { return _suit; }
        }

        public uint Number
        {
            get { return _number; }
        }

        public uint Value
        {
            get { return _multiplier * _number; }
        }
    }
}
