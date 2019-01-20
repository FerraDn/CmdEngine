using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CmdEngine
{
    // An entity is a shape or a point with an id
    public class Entity
    {
        public int Id { get; set; }
        public Shape Shape { get; set;}
        public Point Point { get; set;}

        public Entity(int id, Shape s)
        {
            Id = id;
            Shape = s;
        }
        public Entity(int id, Point P)
        {
            Id = id;
            Point = P;
        }

    }
    class CmdEngine
    {
        private static int Width, Height = 0;
        private Point[,] canvas;


        public CmdEngine(int canvas_width, int canvas_height)
        {
            //Set size of the canvas
            Width = canvas_width;
            Height = canvas_height;
            canvas = new Point[Width, Height];
        }

        //Add a point to the canvas
        public void setPoint(Point p)
        {
            canvas[p.X, p.Y] = p;
        }

        public void setShape(Shape s, Point top_left, bool override_char = false)
        {
            Point[,] traslatedShape = traslatePoints(s.ShapeCanvas, top_left);
            foreach (Point p in traslatedShape)
            {
                //If we don't want to override the symbol, skip
                if (override_char)
                {
                    setPoint(p);
                }
                //Override disabled
                else
                {
                    //If there is already a not empty Point
                    if (!Point.Empty.Equals(p))
                    {
                        setPoint(p);
                    }
                }
            }
        }

        public Point[,] traslatePoints(Point[,] points, Point tr_vector)
        {
            int canvas_newX = points.GetLength(0) + tr_vector.X;
            int canvas_newY = points.GetLength(1) + tr_vector.Y;

            Point[,] newPoints = new Point[canvas_newX, canvas_newY];
            foreach (Point p in points)
            {
                if (!Point.Empty.Equals(p))
                {
                    int new_x = p.X + tr_vector.X;
                    int new_y = p.Y + tr_vector.Y;
                    newPoints[new_x, new_y] = new Point(new_x, new_y);
                }
            }
            return newPoints;
        }

        //Add a point to the canvas
        public Point[,] Canvas()
        {
            return canvas;
        }

        //Remove point to the canvas
        public void removePoint(Point p)
        {
            canvas[p.X, p.Y] = new Point();
        }

        public void clearCanvas()
        {

            foreach (Point p in canvas)
            {
                if (!Point.Empty.Equals(p))
                {
                    Console.SetCursorPosition(p.X, p.Y);
                    Console.Write(" ");
                }
            }

            Array.Clear(canvas, 0, canvas.Length);

        }


        //Print the canvas
        public void PrintAll(char symbol = 'O')
        {
            foreach (Point p in canvas)
            {
                //If the point in the array is not empty
                if (!Point.Empty.Equals(p))
                {
                    Console.SetCursorPosition(p.X, p.Y);
                    Console.Write(symbol);
                }

            }
        }



        
    }
}
