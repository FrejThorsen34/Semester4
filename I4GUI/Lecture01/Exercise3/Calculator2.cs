using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Calculator2
    {
        double result;
        public double Add(double a, double b)
        {
            Result = a + b;
            return result;
        }

        public double Subtract(double a, double b)
        {
            Result = a - b;
            return result;
        }

        public double Multiply(double a, double b)
        {
            Result = a * b;
            return result;
        }

        public double Divide(double a, double b)
        {
            Result = a / b;
            return result;
        }

        public double Power(double a, double b)
        {
            Result = Math.Pow(a, b);
            return result;
        }

        public double Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
