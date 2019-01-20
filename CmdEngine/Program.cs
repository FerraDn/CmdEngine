using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using static CmdEngine.CmdEngine;
using static CmdEngine.Shape;

namespace CmdEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            int cmdW = Console.WindowWidth;
            int cmdH = Console.WindowHeight;

            CmdEngine engine = new CmdEngine(cmdW,cmdH);
            engine.setPoint(new Point((cmdW-1)/2, (cmdH-1)/2));

            while (true)
            {
                engine.clearCanvas();
                engine.setShape(randomShape((cmdW - 1), (cmdH - 1), 3), new Point(0, 0));
                engine.PrintAll();
                Console.ReadLine();
            }

            Console.ReadLine();

        }

        static public Shape randomShape(int max_x, int max_y, int verts)
        {

            Random r = new Random();
            
            List<Point> points = new List<Point>();


            for (int i = 0; i < verts; i++)
            {
                Point p = new Point();
                p.X = r.Next(max_x);
                p.Y = r.Next(max_y);
                points.Add(p);

            }

            return new Shape(points);
        }

        static Point toFirstQuadrant(Point p)
        {
            p.X = Math.Abs(p.X);
            return p;
        }

    }

      
    
}
