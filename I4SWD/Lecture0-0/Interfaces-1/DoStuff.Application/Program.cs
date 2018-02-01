using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoStuff.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the program. Press 1 for DoHickey and 2 for DoDickey");
            var input = Console.ReadLine();

            if (input == "1")
            {
                IDoStuff myStuff = new DoHickey();

                myStuff.DoNothing();
                myStuff.DoSomething(2);
                myStuff.DoSomethingElse("Hej Hickey");
            }
            else if (input == "2")
            {
                IDoStuff myStuff = new DoDickey();

                myStuff.DoNothing();
                myStuff.DoSomething(3);
                myStuff.DoSomethingElse("Hej Dickey");
            }
            else
            {
                Console.WriteLine("You must choose 1 or 2!");
            }

            Console.ReadLine();
        }
    }
}
