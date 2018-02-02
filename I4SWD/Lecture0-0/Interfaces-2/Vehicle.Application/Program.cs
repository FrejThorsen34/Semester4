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
            // ************************************** //
            // *** Gas engine and gas-driven bike *** //
            // ************************************** //
            var myGasEngine = new GasEngine(100);
            var myGasMotorBike = new MotorBike(myGasEngine);
            var thr = myGasEngine.CurThrottle;
            Console.WriteLine($"My gas throttle when idling is: {thr}.");
            thr = myGasEngine.MaxThrottle;
            Console.WriteLine($"My gas throttle at full speed is: {thr}");
            myGasMotorBike.RunAtHalfSpeed();
            thr = myGasEngine.CurThrottle;
            Console.WriteLine($"My gas throttle at half speed is: {thr}");

            // ******************************************** //
            // *** Diesel engine and diesel-driven bike *** //
            // ******************************************** //
            var myDieselEngine = new DieselEngine(120);
            var myDieselMotorBike = new MotorBike(myDieselEngine);
            // Diesel-bike outputs:
            var thr2 = myDieselEngine.CurThrottle;
            Console.WriteLine($"My diesel throttle when idling is: {thr2}");
            thr2 = myDieselEngine.MaxThrottle;
            Console.WriteLine($"My diesel throttle at full speed is: {thr2}");
            myDieselMotorBike.RunAtHalfSpeed();
            thr2 = myDieselEngine.CurThrottle;
            Console.WriteLine($"My diesel throttle at half speed is: {thr2}");

            // ************************************************ //
            // *** Electric engine and electric-driven bike *** //
            // ************************************************ //
            var myElectricEngine = new ElectricEngine(168);
            var myElectricMotorBike = new MotorBike(myElectricEngine);
            // Electric-bike outputs:
            var thr3 = myElectricEngine.CurThrottle;
            Console.WriteLine($"My electric throttle when idling is: {thr3}");
            thr3 = myElectricEngine.MaxThrottle;
            Console.WriteLine($"My electric throttle at full speed is: {thr3}");
            myElectricMotorBike.RunAtHalfSpeed();
            thr3 = myElectricEngine.CurThrottle;
            Console.WriteLine($"My electric throttle at half speed is: {thr3}");

            Console.ReadLine();
        }
    }
}
