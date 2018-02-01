using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperbound = 100;
            int lowerbound = 1;
            int guess = 50;
            bool correct = false;

            Console.WriteLine("*** Welcome to the High-Low game! ***");
            Console.WriteLine("You think of a number between 1 and 100. I will try to guess it!");

            while (!correct)
            {
                Console.WriteLine($"My guess is: {guess}");
                Console.WriteLine("Tell me if Im <H>igh, <L>ow or <E>qual?");
                string input = Console.ReadLine();

                if (input == "L" || input == "l")
                {
                    lowerbound = guess + 1;
                    if (lowerbound >= upperbound)
                    {
                        Console.WriteLine("You cheated!");
                        correct = true;
                        break;
                    }

                    guess = lowerbound + ((upperbound - lowerbound) / 2);
                }

                else if (input == "H" || input == "h")
                {
                    upperbound = guess - 1;
                    if (upperbound <= lowerbound)
                    {
                        Console.WriteLine("You cheated!");
                        correct = true;
                        break;
                    }

                    guess = upperbound - ((upperbound - lowerbound) / 2);
                }

                else if (input == "E" || input == "e")
                {
                    Console.WriteLine("*** I GOT IT! ***");
                    correct = true;
                }

                else
                {
                    Console.WriteLine("You must type <H>, <L> or <E>");
                }
            }

            Console.ReadLine();
        }
    }
}
