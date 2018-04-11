using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public class MyRandom : IRandom
    {
        public uint Next(int lower, int higher)
        {
            var n = (uint)new Random().Next(lower, higher);
            return n;
        }
        public uint Next()
        {
            var n = (uint)new Random().Next(0, 37);
            return n;
        }
    }
}