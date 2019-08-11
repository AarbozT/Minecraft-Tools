using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.Functions;
namespace Mathematics.BaseClasses  
{
 public abstract class PolarCyclicCurveBase:CyclicCurveBase 
    {

        public abstract double R(double theta);
        public abstract double Dr(double theta);
        private Curve mC;
      
         static Cos sCos = new Cos();
         static Sin sSin = new Sin();

         protected PolarCyclicCurveBase() {
         Function r = new Function(R,Dr);
         mC = new Curve( r * sCos ,  r * sSin );
         }

         

         

         public override double X(double t)
         {
             return mC.X(t);
         }

         public override double Y(double t)
         {
             return mC.Y(t);
         }


         public override double Dx(double t)
         {
             return mC.Dx(t);
         }

         public override double Dy(double t)
         {
             return mC.Dy(t);
         }




        
    }
    }
 
