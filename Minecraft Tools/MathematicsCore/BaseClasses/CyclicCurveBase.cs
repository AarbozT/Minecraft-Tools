using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathematics.BaseClasses  
{
  public abstract class CyclicCurveBase:CurveBase 
    {
      public abstract double CycleStart {get;}
      public abstract double CycleEnd{ get;}
    }
}
