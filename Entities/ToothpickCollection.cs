using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ToothpickCollection
    {
        public double ToothpickLength { get; set; }

        public List<Toothpick> Toothpicks = new List<Toothpick>();

        public List<List<Toothpick>> ToothpickIterations = new List<List<Toothpick>>();

        public int IterationCount { get; set; }


        public ToothpickCollection(int iterations)
        {
            ToothpickLength = 1;
            IterationCount = iterations;
            var init = new Toothpick(1, 1, 1, 2);
            //var init = new Toothpick(1, 1, 1.5, 2);

            this.Toothpicks.Add(init);
            this.ToothpickIterations.Add(new List<Toothpick>() { init });
            for (int i = 0; i < IterationCount; i++)
            {
                var newpicks = Add();
                this.ToothpickIterations.Add(newpicks);

            }
        }

        public int Count(double x0, double y0, double x1, double y1)
        {
            var num = 0;
            foreach (var pick in this.Toothpicks)
            {
                if (pick.x0 == x0 && pick.x1 == x1 && pick.y0 == y0 && pick.y1 == y1)
                {
                    num++;
                }
                else if (pick.x1 == x0 && pick.x0 == x1 && pick.y1 == y0 && pick.y0 == y1)
                {
                    num++;
                }

            }
            return num;
        }

        public int Count(double x, double y)
        {
            var num = 0;

            foreach (var pick in this.Toothpicks)
            {
                if ((pick.x0 == x && pick.y0 == y) || (pick.x1 == x) && (pick.y1 == y))
                {
                    num++;
                }

            }

            return num;

        }

        public List<Toothpick> Add()
        {
            var newpicks = new List<Toothpick>();
            foreach (var pick in this.Toothpicks)
            {
                var pcount1 = Count(pick.x0, pick.y0);
                if (pcount1 < 2)
                {
                    var x3 = pick.x0 - (pick.y1 - pick.y0) / 2;
                    var y3 = pick.y0 + (pick.x1 - pick.x0) / 2;
                    var x4 = pick.x0 + (pick.y1 - pick.y0) / 2;
                    var y4 = pick.y0 - (pick.x1 - pick.x0) / 2;

                    var newpick1 = new Toothpick(x3, y3, x4, y4);
                    var dupe = Count(newpick1.x0, newpick1.y0, newpick1.x1, newpick1.y1);
                    if (dupe == 0)
                    {
                        newpicks.Add(newpick1);
                    }
                }

                var pcount2 = Count(pick.x1, pick.y1);
                if (pcount2 < 2)
                {
                    var x3b = pick.x1 - (pick.y1 - pick.y0) / 2;
                    var y3b = pick.y1 + (pick.x1 - pick.x0) / 2;
                    var x4b = pick.x1 + (pick.y1 - pick.y0) / 2;
                    var y4b = pick.y1 - (pick.x1 - pick.x0) / 2;

                    var newpick2 = new Toothpick(x3b, y3b, x4b, y4b);
                    var dupe = Count(newpick2.x0, newpick2.y0, newpick2.x1, newpick2.y1);
                    if (dupe == 0)
                    {
                        newpicks.Add(newpick2);
                    }
                }


            }

            this.Toothpicks.AddRange(newpicks);
            return newpicks;
        }

        public double xMax()
        {
            var x0Max = this.Toothpicks.Select(e => e.x0).Max();
            var x1Max = this.Toothpicks.Select(e => e.x1).Max();
            if (x0Max > x1Max)
            {
                return x0Max;
            }
            else
            {
                return x1Max;
            }
        }
        public double xMin()
        {
            var x0Min = this.Toothpicks.Select(e => e.x0).Min();
            var x1Min = this.Toothpicks.Select(e => e.x1).Min();
            if (x0Min < x1Min)
            {
                return x0Min;
            }
            else
            {
                return x1Min;
            }
        }
        public double yMax()
        {
            var y0Max = this.Toothpicks.Select(e => e.y0).Max();
            var y1Max = this.Toothpicks.Select(e => e.y1).Max();
            if (y0Max > y1Max)
            {
                return y0Max;
            }
            else
            {
                return y1Max;
            }
        }
        public double yMin()
        {
            var y0Min = this.Toothpicks.Select(e => e.y0).Min();
            var y1Min = this.Toothpicks.Select(e => e.y1).Min();
            if (y0Min < y1Min)
            {
                return y0Min;
            }
            else
            {
                return y1Min;
            }
        }

    }

}
