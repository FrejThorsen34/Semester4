using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
	public class BlueCard : ICard
	{
		private int _multiplier = 2;

		public BlueCard(int number)
		{
			Number = number;
		}

		public string Suit { get; } = "Blue";

		public int Number { get; }

		public int Value
		{
			get { return _multiplier * Number; }
		}
	}
}
