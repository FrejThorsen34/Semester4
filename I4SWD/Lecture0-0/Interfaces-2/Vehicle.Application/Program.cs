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
            var myDieselEngine = new DieselEngine(120);
            var myMotorBike2 = new MotorBike(myDieselEngine);
            var myMotorBike = new MotorBike(myGasEngine);

            var thr = myGasEngine.GetThrottle();
            Console.WriteLine($"My throttle is: {thr}.");

            var thr2 = myDieselEngine.GetThrottle();
            Console.WriteLine($"My throttle is: {thr2}");

            myMotorBike.RunAtHalfSpeed();
            thr = myGasEngine.GetThrottle();
            Console.WriteLine($"My throttle at half speed is: {thr}");

            myMotorBike2.RunAtHalfSpeed();
            thr2 = myGasEngine.GetThrottle();
            Console.WriteLine($"My throttle at half speed is: {thr2}");

            Console.ReadLine();
        }
    }
}
