using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Toothpick
    {
        public double x0 { get; set; }
        public double y0 { get; set; }

        public double x1 { get; set; }
        public double y1 { get; set; }

        public bool End1Filled { get; set; }
        public bool End2Filled { get; set; }

        public double Slope()
        {
            var mx = x1 - x0;
            var my = y1 - y0;

            if (mx == 0)
            {
                mx = double.MinValue;
            }
            return my / mx;

        }
        public Toothpick(double x0, double y0, double x1, double y1)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
            this.End1Filled = false;
            this.End2Filled = false;
        }
    }

}
