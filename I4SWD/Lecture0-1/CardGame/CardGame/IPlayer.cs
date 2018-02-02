﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public interface IPlayer
    {
        string Name { get; }

        int Value { get; }

        void ShowHand();

        void TotalValue();

        void DealCard(ICard card);
    }
}
