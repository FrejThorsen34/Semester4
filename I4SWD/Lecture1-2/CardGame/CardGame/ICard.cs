using System;

namespace CardGame
{
    public interface ICard
    {
        string Suit { get; }

        uint Number { get; }

        uint Value { get; }
    }
}
