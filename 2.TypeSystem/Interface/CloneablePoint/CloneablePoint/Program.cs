using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    // A class named Point.
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos; Y = yPos;
        }
        public Point() { }
        
        // Override Object.ToString().
        public override string ToString()
        { return string.Format("X = {0}; Y = {1}", X, Y); }

        // Return a copy of the current object
        public object Clone()
        {
            return new Point(this.X, this.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");
            // Two references to same object!
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            // Notice Clone() returns a plain object type.
            // You must perform an explicit cast to obtain the derived type.
            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone();
            // Change p4.X (which will not change p3.X).
            p4.X = 0;
            // Print each object.
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.ReadLine();
        }
    }
}
