using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GameLogic.Model
{
    public class Player
    {
        public int Bitcoins { get; set; }
        public int Laptops { get; set; }
        public int LaptopLength { get; set; }
        public int MaxLaptops { get; set; }

        public string Id { get; set; }
        public Player(string id = null)
        {
            Bitcoins = 0;
            Laptops = 1;
            MaxLaptops = Laptops;
            LaptopLength = 1;
            Id = id;
        }

    }
}
