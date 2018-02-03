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
            Deck myDeck = new Deck(32);
            Game myGame = new Game(myDeck);

            IPlayer player1 = new Player("Bob");
            IPlayer player2 = new Player("Joe");
            IPlayer player3 = new Player("Sue");

            myGame.AddPlayer(player1);
            myGame.AddPlayer(player2);
            myGame.AddPlayer(player3);

            myGame.DealAllPlayers(3);

            player1.ShowHand();
            Console.WriteLine($"The total value of {player1.Name}'s hand is {player1.TotalValue()}!");
            player2.ShowHand();
            Console.WriteLine($"The total value of {player2.Name}'s hand is {player2.TotalValue()}!");
            player3.ShowHand();
            Console.WriteLine($"The total value of {player3.Name}'s hand is {player3.TotalValue()}!");

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
