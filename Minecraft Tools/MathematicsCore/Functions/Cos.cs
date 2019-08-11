using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics.Functions
{
    class Cos : FunctionBase
    {
       

        public double A { get; private set; }
        public double N { get; private set; }
        public double D { get; private set; }

        public Cos()
        {
             A = 1;
             N = 1;
             D = 0;
        }
        public Cos(double a, double n, double d)
        {
             A = a;
             N = n;
             D = d;
        }

        public override double Value(double x)
        {
            return  A * Math.Cos( N * x +  D);
        }

        public override double Derivative(double x)
        {
            return - N *  A * Math.Sin( N * x +  D);
        }
    }
}
