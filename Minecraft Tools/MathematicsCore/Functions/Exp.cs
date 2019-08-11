using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics.Functions
{
  public  class Exp :FunctionBase 
    {

      public double A { get; private set; }
      public double K { get; private set; }
      public double D { get; private set; } 

      public Exp()
      {
          A = 1;
          K = 1;
          D = 0;

      }
        public override double Value(double x)
        {
           return A * Math.Exp(x * K + D) ;
        }

        public override double Derivative(double x)
        {
            return A * K * Math.Exp(x * K + D);
        }
    }
}
