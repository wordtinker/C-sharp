using System;
using System.Collections.Generic;

namespace CollectionInitSyntax
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", X, Y);
        }
    }

    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", TopLeft, BottomRight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> myListOfRects = new List<Rectangle>
            {
                new Rectangle {TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 200, Y = 200}},
                new Rectangle {TopLeft = new Point { X = 2, Y = 2 },
                BottomRight = new Point { X = 100, Y = 100}},
                new Rectangle {TopLeft = new Point { X = 5, Y = 5 },
                BottomRight = new Point { X = 90, Y = 75}}
            };

            foreach (var r in myListOfRects)
            {
                Console.WriteLine(r);
            }
        }
    }
}
