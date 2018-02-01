using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class MotorBike : IEngine
    {
        public uint MaxThrottle { get; }

        public uint Throttle { get; set; }
        private GasEngine _engine = null;
        // private DieselEngine _engine = null;

        MotorBike(GasEngine engine)
        {
            _engine = engine;
        }

        void RunAtHalfSpeed()
        {
            _engine.Throttle(_engine.MaxThrottle / 2);
        }
    }
}
