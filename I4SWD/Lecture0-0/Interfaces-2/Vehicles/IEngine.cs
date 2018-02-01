using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IEngine
    {
        uint MaxThrottle { get; }

        uint Throttle { get; set; }
    }
}
