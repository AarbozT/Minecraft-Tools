using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics
{
 public   class CyclicCurve:CyclicCurveBase 
    {

        private Func<double, double> mX;
        private Func<double, double> mDx;

        private Func<double, double> mY;
        private Func<double, double> mDy;
        private double mCycleStart;
        private double mCycleEnd;

        public CyclicCurve(Function x, Function y, double cycleStart, double cycleEnd)
        {
            mX = x.Value;
            mDx = x.Derivative;

            mY = y.Value;
            mDy = y.Derivative;
            mCycleStart = cycleStart;
            mCycleEnd = cycleEnd;
        }


        public override double CycleStart
        {
            get { return mCycleStart; }
        }

        public override double CycleEnd
        {
            get { return mCycleEnd; }
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
