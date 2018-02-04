using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
	public class YellowCard : ICard
	{
		private int _multiplier = 4;
		private int _number;
		private string _suit = "Yellow";

		public YellowCard(int number)
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
			get { return _multiplier * Number; }
		}
	}
}
