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
            Deck myDeck = new Deck(33);
            Game myGame = new Game(myDeck);

            IPlayer player1 = new Player("Bob");
            IPlayer player2 = new Player("Joe");
            IPlayer player3 = new Player("Sue");
            IPlayer player4 = new Player("Moe");
            IPlayer player5 = new Player("Lui");
            IPlayer player6 = new Player("Ann");
            IPlayer player7 = new Player("Han");
            IPlayer player8 = new Player("Lee");
            IPlayer player9 = new Player("Kim");
            IPlayer player10 = new Player("Joy");
            IPlayer player11 = new Player("Jim");

            myGame.AddPlayer(player1);
            myGame.AddPlayer(player2);
            myGame.AddPlayer(player3);
            myGame.AddPlayer(player4);
            myGame.AddPlayer(player5);
            myGame.AddPlayer(player6);
            myGame.AddPlayer(player7);
            myGame.AddPlayer(player8);
            myGame.AddPlayer(player9);
            myGame.AddPlayer(player10);
            // myGame.AddPlayer(player11); // Throws exception

            myGame.DealAllPlayers(3);
            // myGame.DealAllPlayers(1); // Throws exception

            foreach (var IPlayer in myGame._players)
            {
                IPlayer.ShowHand();
                Console.WriteLine($"The total value of {IPlayer.Name}'s hand is {IPlayer.TotalValue()}!");
            }

            if (myGame.Winner().Count() == 1)
            {
                Console.WriteLine($"The game had one winner! The winner is {myGame.Winner()[0].Name}");
            }
            else
            {
                Console.WriteLine($"The game had {myGame.Winner().Count()} winners! The winners are: ");
                foreach (var IPlayer in myGame.Winner())
                {
                    Console.WriteLine($"{IPlayer.Name} !!");
                }
            }
            Console.ReadLine();
        }
    }
}
