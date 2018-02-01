using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoStuff
{
    public class DoDickey : IDoStuff
    {
        public void DoNothing()
        {
            Console.WriteLine("DoDickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine($"DoDickey::DoSomething(): {number}");
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine($"DoDickey::DoSomethingElse(): {input}");
            return input;
        }
    }
}
