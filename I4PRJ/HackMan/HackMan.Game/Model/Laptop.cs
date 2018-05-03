using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class Laptop
    {
        public Laptop()
        { }

        public Laptop(Position pos)
        {
            Position = pos;
        }
        public Position Position { get; set; }
        public string TimePlaced { get; set; }
    }
}
