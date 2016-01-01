using System;

namespace Structs
{
    struct Point
    {
        // Fields of the structure.
        public int X;
        public int Y;

        // The default constructor is reserved

        // A custom constructor.
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Add 1 to the (X, Y) position.
        public void Increment()
        {
            X++; Y++;
        }
        // Subtract 1 from the (X, Y) position.
        public void Decrement()
        {
            X--; Y--;
        }
        // Display the current position.
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an initial Point.
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            // Adjust the X and Y values.
            myPoint.Increment();
            myPoint.Display();
            // Set all fields to default values
            // using the default constructor.
            Point p1 = new Point();
            // Prints X=0,Y=0.
            p1.Display();
            // Call custom constructor.
            Point p2 = new Point(50, 60);
            // Prints X=50,Y=60.
            p2.Display();

            // Struct is value type
            Point p3 = new Point(10, 10);
            Point p4 = p3;
            // Print both points.
            p3.Display();
            p4.Display();

            // Change p3.X and print again. p4.X is not changed.
            p3.X = 100;
            Console.WriteLine("\n=> Changed p3.X\n");
            p3.Display();
            p4.Display();

            // When a value type contains other reference types,
            // assignment results in a copy of the references.

        }
    }
}
