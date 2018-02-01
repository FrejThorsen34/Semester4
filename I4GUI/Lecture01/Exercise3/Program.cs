using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCalc = new Calculator();

            myCalc.GetNumber("First");
            myCalc.GetNumber("Second");
            myCalc.AddNumbers();
            myCalc.PrintResult();

            Console.ReadKey();
        }
    }
}
