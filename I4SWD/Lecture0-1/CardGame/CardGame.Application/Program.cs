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

            IPlayer winner = myGame.Winner();
            Console.WriteLine($"The winner is: {winner.Name}! Congratulations!");
            Console.ReadLine();
        }
    }
}
