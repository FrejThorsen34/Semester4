using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            var result = a + b;
            Accumulator = result;
            return result;
        }

        public double Add(double addend)
        {
            var result = addend + Accumulator;
            Accumulator = result;
            return result;
        }

        public double Subtract(double a, double b)
        {
            var result = a - b;
            Accumulator = result;
            return result;
        }

        public double Subtract(double subtractor)
        {
            var result = Accumulator - subtractor;
            Accumulator = result;
            return result;
        }
        public double Multiply(double a, double b)
        {
            var result = a * b;
            Accumulator = result;
            return result;
        }

        public double Multiply(double multiplier)
        {
            var result = Accumulator * multiplier;
            Accumulator = result;
            return result;
        }

        public double Power(double a, double b)
        {
            var result = Math.Pow(a, b);
            Accumulator = result;
            return result;
        }

        public double Power(double exponent)
        {
            var result = Math.Pow(Accumulator, exponent);
            Accumulator = result;
            return result;
        }

        public double Divide(double dividend, double divisor)
        {
            try
            {
                var result = dividend / divisor;
                Accumulator = result;
                return result;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"The dividend {dividend} is being divided by zero");
                Accumulator = 0;
                return 0;
            }
        }

        public double Divide(double divisor)
        {
            try
            {
                var result = Accumulator / divisor;
                Accumulator = result;
                return result;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"The dividend {Accumulator} is being divided by zero");
                throw;
            }
        }

        public double Accumulator { get; private set; }

        public void Clear()
        {
            Accumulator = 0;
        }

    }
}
