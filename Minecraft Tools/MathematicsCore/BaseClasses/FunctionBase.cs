using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace Mathematics.BaseClasses  
{
    public abstract class FunctionBase
    {
        public abstract double Value(double x);
        public abstract double Derivative(double x);

        protected FunctionBase(){}
        public double Dy(double x)
        {
            return Derivative(x);

        }

        public double Y(double x)
        {
            return Value(x);
        }


          public List<System.Windows.Point> Points(double start, double end, int segments)
                {
                    List<System.Windows.Point> results = new List<System.Windows.Point>();
                    for (int i = 0; i <= segments; i++)
                    {
                        double a = i * (end - start) / (segments) + start;
                        results.Add(new Point(a, Y(a)));
                    }
                    return results;

                }


        #region Operators

        public static Function operator +(FunctionBase f, FunctionBase g)
        {
            return Sum(f, g);
        }

        public static Function operator -(FunctionBase f, FunctionBase g)
        {
            return Difference(f, g);
        }

        public static Function operator *(FunctionBase f, FunctionBase g)
        {
            return Product(f, g);
        }
        public static Function operator /(FunctionBase f, FunctionBase g)
        {
            return Quotient(f, g);
        }


        #endregion



        #region Chain Rule

        public static Function Compose(FunctionBase outerFunction, FunctionBase innerFunction)
        {
            //Change of variables for more readable code
            FunctionBase f = outerFunction;
            FunctionBase g = innerFunction;
            return new Function(
                x => f.Value(g.Value(x)),                         //Composition f(g(x))
                x => f.Derivative(g.Value(x)) * g.Derivative(x)     //Chain Rule  f'(g(x))*g'(x)
                );
        }

        public static Function Sum(FunctionBase f, FunctionBase g)
        {
            return new Function(x => f.Value(x) + g.Value(x),
                x => f.Derivative(x) + g.Derivative(x)
                );
        }

        public static Function Difference(FunctionBase f, FunctionBase g)
        {
            return new Function(x => f.Value(x) - g.Value(x),
                x => f.Derivative(x) - g.Derivative(x)
                );
        }

        public static Function Product(FunctionBase f, FunctionBase g)
        {
            return new Function(x => f.Value(x) * g.Value(x),
               x => f.Derivative(x) * g.Value(x) + g.Derivative(x) * f.Value(x) //Chain Rule f'(x)g(x) + f(x)g'(x)
               );
        }

        public static Function Quotient(FunctionBase numerator, FunctionBase denominator)
        {
            //Change of variables for more readable code
            FunctionBase f = numerator;
            FunctionBase g = denominator;
            return new Function(x => f.Value(x) / g.Value(x),
                //Chain rule (f'(x)g(x) - f(x)g'(x))/g(x)^2
               x => (f.Derivative(x) * g.Value(x) - f.Value(x) * g.Derivative(x)) / Math.Pow(g.Value(x), 2)
               );
        }

        #endregion

    }
}