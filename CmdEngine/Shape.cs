using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CmdEngine
{
    public class Shape
    {
        static Point[,] Container;
        public static List<Point> vertexes = new List<Point>();
        public char symbol = 'o';

        public Shape(List<Point> Vertexes_List, char Symbol = 'o')
        {

            vertexes = Vertexes_List;
            setContainer();
            linkVertexes();

        }

        public Point[,] ShapeCanvas { get => Container; set => Container = value; }


        private void setContainer()
        {
            Point[] v = getContainerMainVertex();
            int width = v[1].X - v[0].X + 1;
            int height = v[0].Y - v[1].Y + 1;

            Container = new Point[width, height];

        }

        private void linkVertexes()
        {
            for (int i = 0; i < vertexes.Count(); i++)
            {
                if (i == vertexes.Count() - 1)
                    addSegment(vertexes[i], vertexes[0]);
                else
                    addSegment(vertexes[i], vertexes[i + 1]);

            }
        }

        //Getting the opposite vertex of the container (Square)
        private Point[] getContainerMainVertex()
        {
            int max_X = 0;
            int min_X = 0;
            int max_Y = 0;
            int min_Y = 0;

            foreach (Point p in vertexes)
            {
                if (p.X > max_X)
                {
                    max_X = p.X;
                }
                if (p.X < min_X)
                {
                    min_X = p.X;
                }
                if (p.Y > max_Y)
                {
                    max_Y = p.Y;
                }
                if (p.Y < min_Y)
                {
                    min_Y = p.Y;
                }
            }

            return new Point[2] { new Point(min_X, max_Y), new Point(max_X, min_Y) };

        }
        private void addSegment(Point p1, Point p2)
        {
            int x = p1.X;
            int y = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                Container[x, y] = new Point(x, y);


                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

    }
}
