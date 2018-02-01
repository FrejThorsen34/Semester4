using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 100);
            int guess = 0;
            bool correct = false;

            Console.WriteLine("*** Welcome to the High-Low game! ***");
            Console.WriteLine("I am thinking of a number between 1 and 100. Try to guess it!");

            while (!correct)
            {
                Console.Write("Guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("That is not a number.");
                    continue;
                }

                if (guess < numberToGuess)
                {
                    Console.WriteLine("No, the number I am thinking of is HIGHER than " + guess + ". Try again!");
                }
                else if (guess > numberToGuess)
                {
                    Console.WriteLine("No, the number I am thinking of is LOWER than " + guess + ". Try again!");
                }
                else
                {
                    correct = true;
                    Console.WriteLine("Well done! The answer was " + numberToGuess);
                }
            }
            Console.ReadLine();
        }
    }
}
