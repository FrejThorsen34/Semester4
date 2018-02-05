using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck(60);
            IGame myGame = new HighGame(myDeck);

            IPlayer player1 = new Player("Bob");
            IPlayer player2 = new Player("Joe");
            IPlayer player3 = new WeakPlayer("Ann");
            IPlayer player4 = new Player("Sue");
            IPlayer player5 = new Player("Lee");

            myGame.AddPlayer(player1);
            myGame.AddPlayer(player2);
            myGame.AddPlayer(player3);
            myGame.AddPlayer(player4);
            myGame.AddPlayer(player5);

            myGame.DealAllPlayers(5);

            foreach (var player in myGame.GetPlayers())
            {
                player.ShowHand();
                Console.WriteLine($"The total value of {player.Name}'s hand is {player.TotalValue()}!");
            }

            if (myGame.GetWinners().Count() == 1)
            {
                Console.WriteLine($"The game had one winner! The winner is {myGame.GetWinners()[0].Name}");
            }
            else
            {
                Console.WriteLine($"The game had {myGame.GetWinners().Count()} winners! The winners are: ");
                foreach (var player in myGame.GetWinners())
                {
                    Console.WriteLine($"{player.Name} !!");
                }
            }
            Console.ReadLine();
        }
    }
}
