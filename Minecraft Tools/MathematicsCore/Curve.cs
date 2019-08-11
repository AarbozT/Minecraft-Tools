using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics 
{
  public sealed  class Curve:CurveBase 
    {
        private Func<double, double> mX;
        private Func<double, double> mDx;

        private Func<double, double> mY;
        private Func<double, double> mDy;

        public Curve(Function x, Function y)
        {
            mX = x.Value;
            mDx = x.Derivative;

            mY = y.Value;
            mDy = y.Derivative;
        }

        public override double X(double t)
        {
            return mX(t);
        }

        public override double Y(double t)
        {
            return mY(t);
        }

        public override double Dx(double t)
        {
            return mDx(t);
        }

        public override double Dy(double t)
        {
            return mDy(t);
        }
    }
}
