using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics
{
  public  sealed  class PolarCurve:PolarCurveBase 
    {
        private Func<double, double> mR;
        private Func<double, double> mDr;

        public PolarCurve(Function r)
        {
            mR = r.Value;
            mDr = r.Derivative;
        }

        public override double R(double theta)
        {
            return mR(theta);
        }

        public override double Dr(double theta)
        {
            return mDr(theta);
        }
    }
}
