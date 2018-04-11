using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public interface IRoulette
    {
        void Spin();

        Field GetResult();
    }
}