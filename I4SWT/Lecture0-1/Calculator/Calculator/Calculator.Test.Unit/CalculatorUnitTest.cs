using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture()]
    [Author("Gruppe 35")]
    public class CalculatorUnitTest
    {
        private Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();
        }

        [TestCase(2, 4, 6)]
        [TestCase(-4, 8, 4)]
        [TestCase(3, -7, -4)]
        public void Add_AddNumber1AndNumber2_ReturnsCorrectResult(double a, double b, double c)
        {
            Assert.That(_uut.Add(a, b), Is.EqualTo(c));
        }

        [TestCase(1, 2, 3, 6)]
        [TestCase(-4, 2, 5, 3)]
        [TestCase(5, -7, -1, -3)]
        public void Add_Add_AddNumber1AndNumber2AndNumber3_ReturnsCorrectResult(double a, double b, double c, double d)
        {
            _uut.Add(a, b);
            Assert.That(_uut.Add(c), Is.EqualTo(d));
        }

        [TestCase(2, 4, -2)]
        [TestCase(0, 4, -4)]
        [TestCase(4, 2, 2)]
        [TestCase(-3, -3, 0)]
        public void Subtract_SubtractNumber1AndNumber2_ReturnCorrectResult(double a, double b, double c)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(c));
        }

        [TestCase(4, 1, 3, 0)]
        [TestCase(-6, -1, 4, -9)]
        public void Subtract_Subtract_SubtractNumber2AndNumber3FromNumber1_ReturnCorrectResult(double a,
            double b, double c, double d)
        {
            _uut.Subtract(a, b);
            Assert.That(_uut.Subtract(c), Is.EqualTo(d));
        }

        [TestCase(3, 4, 12)]
        [TestCase(0, 5, 0)]
        [TestCase(2, -5, -10)]
        [TestCase(1, 1, 1)]
        public void Multiply_MultiplyNumber1AndNumber2_ReturnCorrectResult(double a, double b, double c)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(c));
        }

        [TestCase(2, 2, 2, 8)]
        [TestCase(4, -2, 3, -24)]
        [TestCase(0, 3, 2, 0)]
        [TestCase(4, -2, -1, 8)]
        public void Multiply_Multiply_MultiplyNumber1AndNumber2AndNumber3_ReturnCorrectResult(double a, double b,
            double c, double d)
        {
            _uut.Multiply(a, b);
            Assert.That(_uut.Multiply(c), Is.EqualTo(d));
        }

        [TestCase(3, 3, 27)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 2, 0)]
        [TestCase(-2, 3, -8)]
        [TestCase(5, -1, 0.2)]
        public void Power_Number1TakenToThePowerOfNumber2_ReturnCorrectResult(double a, double b, double c)
        {
            Assert.That(_uut.Power(a, b), Is.EqualTo(c));
        }

        [TestCase(2, 2, 3, 64)]
        [TestCase(0, 2, 3, 0)]
        [TestCase(3, 2, 0, 1)]
        [TestCase(-5, 2, 2, 625)]
        [TestCase(2, 2, -1, 0.25)]
        public void Power_Power_Number1TakenToThePowerOfNumber2TakenToThePowerOfNumber3_ReturnCorrectResult(double a,
            double b, double c, double d)
        {
            _uut.Power(a, b);
            Assert.That(_uut.Power(c), Is.EqualTo(d));
        }

        [TestCase(6, 2, 3)]
        [TestCase(-4, 2, -2)]
        [TestCase(8, -2, -4)]
        // [TestCase(6, 0, 99999)] <- 99999 should be infinity, or test for exception thrown.
        [TestCase(0, 10, 0)]
        public void Divide_Number1DividedByNumber2_ReturnCorrectResult(double a, double b, double c)
        {
            Assert.That(_uut.Divide(a, b), Is.EqualTo(c));
        }

        [TestCase(8, 2, 1, 4)]
        [TestCase(0, 2, 2, 0)]
        // [TestCase(6, 2, 0, 99999)] <- 99999 should be infinity, or test for exception thrown.
        [TestCase(-8, 2, 2, -2)]
        [TestCase(-12, 2, -3, 2)]
        public void Divide_Divide_Number1DividedByNumber2DividedByNumber3_ReturnCorrectResult(double a, double b,
            double c, double d)
        {
            _uut.Divide(a, b);
            Assert.That(_uut.Divide(c), Is.EqualTo(d));
        }

        [TestCase(8, 2, 4, -4, -16, 14, -2, -1, -0.5)]
        [TestCase(-12, 3, -4, 10, -40, -10, -50, 3, -125000)]
        // [TestCase(4, 0, 99999, -1, -99999, 14, -99999, 1, -99999)] <- 99999 should be infinity, and -99999 should be negativve infinity, or exception thrown.
        public void Add_Divide_Multiply_Add_Power_AddNumber1DivideByNumber2MultiplyByNumber4AddNumber6TakenToThePowerOfNumber8_ReturnCorrectResult (double a, 
            double b, double c, double d, double e, double f, double g, double h, double i)
        {
            Assert.That(_uut.Add(a), Is.EqualTo(a));
            Assert.That(_uut.Divide(b), Is.EqualTo(c));
            Assert.That(_uut.Multiply(d), Is.EqualTo(e));
            Assert.That(_uut.Add(f), Is.EqualTo(g));
            Assert.That(_uut.Power(h), Is.EqualTo(i));
        }
    }
}
