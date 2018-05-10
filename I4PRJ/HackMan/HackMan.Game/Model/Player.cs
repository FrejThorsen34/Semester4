using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class Player
    {
        public int Bitcoins { get; set; }
        public int Laptops { get; set; }
        public int LaptopLength { get; set; }
        public int MaxLaptops { get; set; }

        public Player()
        {
            Bitcoins = 0;
            Laptops = 1;
            MaxLaptops = Laptops;
            LaptopLength = 1;
        }

    }
}
