using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_ATM_Handin3.System.Interfaces;

namespace SWT_ATM_Handin3.System.Boundary
{
    public class Display : IDisplay
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        public void WriteRed(string output)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(output);
            Console.ResetColor();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
