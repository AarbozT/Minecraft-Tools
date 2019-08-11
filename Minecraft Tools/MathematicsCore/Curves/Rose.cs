using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.BaseClasses;
namespace Mathematics.Curves
{
 public  sealed class Rose:PolarCyclicCurveBase 
    {
     public  double  A{get;private set;}
     public double Omega { get; private set; }
     public int N { get; private set; }
     public int D { get; private set; }


         public Rose(double a, int n, int d)
         {
             D = d;
             N = n;
             A = a;
              Omega = (double)n / d;
           

         }

        public override double R(double theta)
        {
            return A * Math.Sin(Omega * theta);
        }

        public override double Dr(double theta)
        {
            return Omega * A * Math.Cos(Omega * theta);
        }

        public override double CycleStart
        {
            get { return 0; }
        }

        public override double CycleEnd
        {
            
            get {double cycle = D * 2* Math.PI / gcd(N, D);
             if (N == 1  && D % 2 ==1) { cycle = cycle / 2; }
            return cycle;
            }
        }

      private  int gcd(int a, int b)
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
