﻿using System;
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
            IPlayer player3 = new WeakPlayer("Ann");

            myGame.AddPlayer(player1);
            myGame.AddPlayer(player2);
            myGame.AddPlayer(player3);
            // myGame.AddPlayer(player11); // Throws exception

            myGame.DealAllPlayers(5);
            // myGame.DealAllPlayers(1); // Throws exception

            foreach (var player in myGame.Players)
            {
                player.ShowHand();
                Console.WriteLine($"The total value of {player.Name}'s hand is {player.TotalValue()}!");
            }

            if (myGame.Winner().Count() == 1)
            {
                Console.WriteLine($"The game had one winner! The winner is {myGame.Winner()[0].Name}");
            }
            else
            {
                Console.WriteLine($"The game had {myGame.Winner().Count()} winners! The winners are: ");
                foreach (var player in myGame.Winner())
                {
                    Console.WriteLine($"{player.Name} !!");
                }
            }
            Console.ReadLine();
        }
    }
}
