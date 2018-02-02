using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
	public class YellowCard : ICard
	{
		private int _multiplier = 4;

		public YellowCard(int number)
		{
			Number = number;
		}

		public string Suit { get; } = "Yellow";

		public int Number { get; }

		public int Value
		{
			get { return _multiplier * Number; }
		}
	}
}
