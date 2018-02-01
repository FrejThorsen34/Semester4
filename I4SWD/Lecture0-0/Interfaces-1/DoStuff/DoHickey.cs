using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoStuff
{
    public class DoHickey : IDoStuff
    {
        public void DoNothing()
        {
            Console.WriteLine("DoHickey::DoNothing()");
        }

        public int DoSomething(int number)
        {
            Console.WriteLine($"DoHickey::DoSomething(): {number}");
            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.WriteLine($"DoHickey::DoSomethingElse(): {input}");
            return input;
        }
    }
}
