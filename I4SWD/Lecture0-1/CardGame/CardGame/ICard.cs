using System;

namespace CardGame
{
    public interface ICard
    {
        string Suit { get; }

        int Number { get; }

        int Value { get; }
    }
}
