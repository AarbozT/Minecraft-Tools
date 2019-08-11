using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics.Functions
{
    class Sin : FunctionBase
    {
        /// <summary>
        /// The Amplitude of the sin function, Foe f(x) = Asin(x) it is A
        /// </summary>
        public double A { get; private set; }

        /// <summary>
        ///2Pi times the frequency,  For f(x) = sin(nx)  it is n
        ///  /// </summary>
        public double N { get; private set; }

        /// <summary>
        /// The phase shif, For f(x) = sin(x + d) it is d
        /// </summary>
        public double D { get; private set; }


        public Sin(double a, double n, double d)
        {
             A = a;N = n; D = d;
        }

        public Sin() :this(1,1,0){}
        
        public Sin(double a, double n):this(a,n,0) {}   
        

        public override double Value(double x)
        {
            return  A * Math.Sin( N * x +  D);
        }

        public override double Derivative(double x)
        {
            return  N *  A * Math.Cos( N * x +  D);
        }
    }
}
