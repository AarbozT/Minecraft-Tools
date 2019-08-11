using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics
{
  public sealed  class Function:FunctionBase
    {
        private Func<double, double> mF;
        private Func<double, double> mDF;

        public Function( Func<double,double> f, Func<double,double> df)
      {
          mF = f;
          mDF = df;
      }

        public override double Value(double x)
        {
            return mF(x);
        }

        public override double Derivative(double x)
        {
            return mDF(x);
        }
    }
}
