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
            player2.ShowHand();
            player3.ShowHand();

            IPlayer winner = myGame.Winner();
            Console.WriteLine($"The winner is: {winner.Name}! Congratulations!");
            Console.ReadLine();
        }
    }
}
