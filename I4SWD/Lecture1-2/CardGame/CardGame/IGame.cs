using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public interface IGame
    {
        List<IPlayer> GetWinners();

        List<IPlayer> GetPlayers();

        void AddPlayer(IPlayer player);

        void DealAllPlayers(uint numberOfCards);
    }
}
