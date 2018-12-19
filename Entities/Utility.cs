using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Utility
    {
        public static double Map(double s, double a1, double a2, double b1, double b2)
        {
            var denom = (a2 - a1);
            if (denom == 0)
            {
                denom = double.MinValue;
            }

            return b1 + (s - a1) * (b2 - b1) / denom;
        }
    }
}
