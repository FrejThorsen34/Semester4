using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Altitude { get; set; }
        public Point(int x = 0, int y = 0, int alt = 0)
        {
            X = x;
            Y = y;
            Altitude = alt;
        }
    }
}
