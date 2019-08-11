using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace Mathematics.BaseClasses 
{
  public abstract  class CurveBase
    {

       public abstract Double X(double t);
    
       public abstract Double Y(double t);
       
       public abstract Double Dx(double t);

       public abstract Double Dy(double t);

 protected  CurveBase()
       {
       }

       
       public List<System.Windows.Point> Points(double start, double end, int segments)
       {
           List<System.Windows.Point> results = new List<System.Windows.Point>();
           for (int i = 0; i <= segments; i++)
           {
               double a = i * (end - start) / (segments) + start;
               results.Add(new Point(X(a),Y(a)));
           }
           return results;

       }

      public double Slope(double t){
          return Dy(t) / Dx(t);

      }
    }
}
