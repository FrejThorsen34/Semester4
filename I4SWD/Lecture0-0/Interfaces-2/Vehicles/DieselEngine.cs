﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class DieselEngine : IEngine
    {
        private uint _curThrottle = 0;
        private uint _maxThrottle = 0;

        public DieselEngine(uint maxThrottle)
        {
            _maxThrottle = maxThrottle;
        }

        public uint MaxThrottle
        {
            get { return _maxThrottle; }
        }

        public void SetThrottle(uint thr)
        {
            _curThrottle = thr;
        }

        public uint GetThrottle()
        {
            return _curThrottle;
        }
    }
}
