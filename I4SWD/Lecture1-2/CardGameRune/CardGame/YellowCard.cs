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
			if (number >= 1 && number <= 8)
				_number = number;
			else
				throw new ArgumentOutOfRangeException("Invalid number, Number must be between 1 and 8");
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
