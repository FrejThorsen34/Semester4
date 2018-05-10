using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game.Helper
{
    public class RandomGenerator
    {
        private Random _random;

        public RandomGenerator()
        {
            _random = new Random();
        }

        public bool DropOrNotDrop()
        {
            if (_random.Next(2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
