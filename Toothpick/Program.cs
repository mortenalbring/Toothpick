using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);

            var iterationCount = 30;
            Console.WriteLine("Calculating..");
            var col = new ToothpickCollection(iterationCount);
            Console.Clear();
            //Draw(col);



            var pickCount = 0;
            for (int i = 0; i < iterationCount; i++)
            {
                Thread.Sleep(1000);
                // Console.Clear();               
                Draw2(col, i);

                Console.SetCursorPosition(0, 0);
                
                pickCount = pickCount + col.ToothpickIterations[i].Count;
                Console.Write(i.ToString().PadRight(10) + pickCount);
                Debug.WriteLine(i + "\t" + pickCount);
                // Console.ReadKey();
            }


            Console.ReadLine();
        }

        public static void Draw2(ToothpickCollection toothpicks, int currentIteration)
        {

            var w = (double)(Console.WindowWidth - 2);
            var h = (Console.WindowHeight - 2);

            var xMin = toothpicks.xMin();
            var xMax = toothpicks.xMax();

            var yMin = toothpicks.yMin();
            var yMax = toothpicks.yMin();
         
            var iter = toothpicks.ToothpickIterations[currentIteration];

            foreach (var pick in iter)
            {
                var x0m = Utility.Map(pick.x0, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y0m = Utility.Map(pick.y0, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

                var x1m = Utility.Map(pick.x1, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y1m = Utility.Map(pick.y1, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

                Console.SetCursorPosition((int)x0m, (int)y0m);
                Console.Write('.');

                Console.SetCursorPosition((int)x1m, (int)y1m);
                Console.Write('.');

                DrawBetween(x0m, y0m, x1m, y1m, 10);

            }


        }
        public static void Draw(ToothpickCollection toothpicks)
        {

            foreach (var pick in toothpicks.Toothpicks)
            {
                var w = (double)(Console.WindowWidth - 2);
                var h = (Console.WindowHeight - 2);

                var x0m = Utility.Map(pick.x0, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y0m = Utility.Map(pick.y0, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

                var x1m = Utility.Map(pick.x1, toothpicks.xMin(), toothpicks.xMax(), 1.0, w);
                var y1m = Utility.Map(pick.y1, toothpicks.yMin(), toothpicks.yMax(), 1.0, h);

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
    }

}
