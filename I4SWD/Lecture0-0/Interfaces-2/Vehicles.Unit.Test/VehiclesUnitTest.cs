using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Vehicles.Unit.Test
{
    [TestFixture()]
    [Author("NERK")]
    public class VehiclesUnitTest
    {
        [TestCase((uint)66)]
        public void DieselEngine_Set_Get(uint a)
        {
            DieselEngine _suut = new DieselEngine(a);
            MotorBike _uut = new MotorBike(_suut);
            Assert.That(_suut.CurThrottle = a, Is.EqualTo(a));
            _uut.RunAtHalfSpeed();
            Assert.That(_suut.CurThrottle, Is.EqualTo(a / 2));
        }

        [TestCase((uint)88)]
        public void GasEngine_Set_Get(uint a)
        {
            GasEngine _suut = new GasEngine(a);
            MotorBike _uut = new MotorBike(_suut);
            Assert.That(_suut.CurThrottle = a, Is.EqualTo(a));
            _uut.RunAtHalfSpeed();
            Assert.That(_suut.CurThrottle, Is.EqualTo(a / 2));
        }

        [TestCase((uint)122)]
        public void ElectricEngine_Set_Get(uint a)
        {
            ElectricEngine _suut = new ElectricEngine(a);
            MotorBike _uut = new MotorBike(_suut);
            Assert.That(_suut.CurThrottle = a, Is.EqualTo(a));
            _uut.RunAtHalfSpeed();
            Assert.That(_suut.CurThrottle, Is.EqualTo(a / 2));
        }

    }
}
