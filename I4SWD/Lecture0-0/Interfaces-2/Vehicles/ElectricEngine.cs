using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class ElectricEngine : IEngine
    {
        private uint _curThrottle = 0;
        private uint _maxThrottle = 0;

        public ElectricEngine(uint maxThrottle)
        {
            _maxThrottle = maxThrottle;
        }

        public uint MaxThrottle
        {
            get { return _maxThrottle; }
        }

        public uint CurThrottle
        {
            get { return _curThrottle; }
            set { _curThrottle = value; }
        }
    }
}
