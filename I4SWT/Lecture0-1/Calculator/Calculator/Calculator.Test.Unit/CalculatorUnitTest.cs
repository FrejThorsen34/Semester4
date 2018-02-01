using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture()]
    public class CalculatorUnitTests
    {
        [Test]
        public void Add_Add2And4_Returns6()
        {
            var uut = new Calculator();

            Assert.That(uut.Add(2, 4), Is.EqualTo(6));
        }

        [Test]
        public void Add_AddMinus2And4_Returns2()
        {
            var uut = new Calculator();

            Assert.That(uut.Add(-2, 4), Is.EqualTo(2));
        }

        [Test]
        public void Subtract_Subtract5And2_Returns3()
        {
            var uut = new Calculator();

            Assert.That(uut.Subtract(5, 2), Is.EqualTo(3));
        }

        [Test]
        public void Multiply_Multiply3And4_Returns12()
        {
            var uut = new Calculator();

            Assert.That(uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Power_Power3And3_Returns27()
        {
            var uut = new Calculator();

            Assert.That(uut.Power(3, 3), Is.EqualTo(27));
        }

        [TestCase(3, 3, 27)]
        [TestCase(5, 0, 1)]
        [TestCase(0, 5, 0)]
        [TestCase(5, -1, 0.2)]
        [TestCase(-2, 3, -8)]
        public void Power_Test(double a, double b, double c)
        {
            var uut = new Calculator();

            Assert.That(uut.Power(a,b), Is.EqualTo(c));
        }
    }
}
