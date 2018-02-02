using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
	public class RedCard : ICard
	{
		private int _multiplier = 1;

		public RedCard(int number)
		{
			Number = number;
		}

		public string Suit { get; } = "Red";

		public int Number { get; }

		public int Value
		{
			get { return (_multiplier * Number); }
		}
	}
}
