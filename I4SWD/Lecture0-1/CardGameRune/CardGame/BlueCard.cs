using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
	public class BlueCard : ICard
	{
		private int _multiplier = 2;
		private int _number;
		private string _suit = "Blue";

		public BlueCard(int number)
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
