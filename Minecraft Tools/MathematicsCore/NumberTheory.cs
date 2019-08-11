using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathematics
{
  public static class NumberTheory
    {
      public static int GCD(int a, int b)
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

      public static int LCD(int a, int b)
      {
          return a * b / GCD(a, b);


      }
    }

    
}
