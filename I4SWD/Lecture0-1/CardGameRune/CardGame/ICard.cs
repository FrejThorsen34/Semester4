using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
	public interface ICard
	{
		string Suit { get; }

		int Number { get; }

		int Value { get; }
	}
}
