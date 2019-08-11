using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics
{
  public  class CyclicPolarCurve:PolarCyclicCurveBase 
    {

        private Func<double, double> mR;
        private Func<double, double> mDr;
        private double mCycleStart;
        private double mCycleEnd;

        public CyclicPolarCurve(Function r, double cycleStart, double cycleEnd)
        {
            mR = r.Value;
            mDr = r.Derivative;
            mCycleStart = cycleStart;
            mCycleEnd = cycleEnd;
        }

        

        public override double R(double theta)
        {
            return mR(theta);
        }

        public override double Dr(double theta)
        {
            return mDr(theta);
        }

        public override double CycleStart
        {
            get { return mCycleStart; }
        }

        public override double CycleEnd
        {
            get { return mCycleEnd; }
        }
    }
}
