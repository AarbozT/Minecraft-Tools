using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;

namespace Mathematics.Curves
{
  public  class Lissajous : CyclicCurveBase 
    {
        public double A { get;private  set; }
        public double B { get; private set; }
        public int N { get; private set; }
        public int D { get; private set; }
        public double Omega { get; private set; }
        public double Delta { get; private set; }


        public Lissajous(double a, double b, int n, int d, double delta)
        {
            A = a;
            B = b;
            N = n;
            D = d;
            Omega =(double) n / d;

            Delta = delta;
        }

        public override double X(double t)
        {
            return A * Math.Sin(Omega * t + Delta);
        }
        public override double Y(double t)
        {
            return B * Math.Sin(t);
        }

        public override double Dx(double t)
        {
            return Omega * A * Math.Cos(Omega * t + Delta);
        }

        public override double Dy(double t)
        {
            return B * Math.Cos(t);

        }

        public override double CycleStart
        {
            get { return 0; }
        }

        public override double CycleEnd
        {
            get { return (double) Math.PI * 2 * D / gcd(N,D); }
        }

        private int gcd(int a, int b)
        {
            int temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
