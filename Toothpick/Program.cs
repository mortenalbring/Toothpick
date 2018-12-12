using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Toothpick
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = new ToothpickCollection();
            Draw(col);


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                col.Add();
                Draw(col);
            }


            Console.ReadLine();
        }

        public static void Draw(ToothpickCollection toothpicks)
        {

            foreach(var pick in toothpicks.Toothpicks)
            {
                var w = (double)(Console.WindowWidth - 2);
                var h = (Console.WindowHeight - 2);

                var x0m = map(pick.x0, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y0m = map(pick.y0, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

                var x1m = map(pick.x1, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y1m = map(pick.y1, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);


                Console.SetCursorPosition((int)x0m, (int)y0m);
                Console.Write("a");

                Console.SetCursorPosition((int)x1m, (int)y1m);
                Console.Write("b");

                DrawBetween(x0m, y0m, x1m, y1m, 10);
            }


        }

        public static void DrawBetween(double x0, double y0, double x1, double y1, int points)
        {
            var mx = x1 - x0;
            var my = y1 - y0;

            for (int r = 1; r < points; r++)
            {
                var lx = (x0) + (0.1 * mx * r);
                var ly = (y0) + (0.1 * my * r);

                Console.SetCursorPosition((int)lx, (int)ly);
                Console.Write('.');
            }
        }

        

        public static double map(double s, double a1, double a2, double b1, double b2)
        {
            var denom = (a2 - a1);
            if (denom == 0)
            {
                denom = double.MinValue;
            }

            return b1 + (s - a1) * (b2 - b1) / denom;
        }


    }

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

 
    public class ToothpickCollection
    {
        public double Length { get; set; }

        public List<Toothpick> Toothpicks = new List<Toothpick>();

        public ToothpickCollection()
        {
            Length = 1;
            var init = new Toothpick(1,1,1,2);

            
            this.Toothpicks.Add(init); 
        }

        public void Add()
        {
            var newpicks = new List<Toothpick>();
            foreach(var pick in this.Toothpicks)
            {                            
                var x3 = pick.x0 - (pick.y1 - pick.y0) / 2;
                var y3 = pick.y0 + (pick.x1 - pick.x0) / 2;
                var x4 = pick.x0 + (pick.y1 - pick.y0) / 2;
                var y4 = pick.y0 - (pick.x1 - pick.x0) / 2;            


                var newpick = new Toothpick(x3, y3, x4, y4);
              
                newpicks.Add(newpick);            
            }

            this.Toothpicks.AddRange(newpicks);

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
