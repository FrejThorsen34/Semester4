using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Vehicle.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGasEngine = new GasEngine(100);
            var myMotorBike = new MotorBike(myGasEngine);

            var thr = myGasEngine.GetThrottle();
            Console.WriteLine($"My throttle is: {thr}.");

            myMotorBike.RunAtHalfSpeed();
            thr = myGasEngine.GetThrottle();
            Console.WriteLine($"My throttle at half speed is: {thr}");
        }
    }
}
