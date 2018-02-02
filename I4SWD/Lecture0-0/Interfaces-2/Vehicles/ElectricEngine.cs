using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class ElectricEngine : IEngine
    {
        public ElectricEngine(uint maxThrottle)
        {
            MaxThrottle = maxThrottle;
        }

        public uint MaxThrottle { get; }

        public uint CurThrottle { get; set; }
    }
}
