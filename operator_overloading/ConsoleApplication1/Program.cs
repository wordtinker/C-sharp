using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Vector
    {
        private double x, y, z;
        public Vector(double xC, double yC, double zC)
        {
            x = xC; y = yC; z = zC;
        }
        public static Vector operator +(Vector vec1, Vector vec2)
        {
            // same as object.__add__(self, other) in Python
            return new Vector(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }
        public override string ToString()
        {
            // same as __repr__ in Python
            return String.Format("<{0},{1},{2}>", x, y, z);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);
            Console.WriteLine("The sum of {0} and {1} is {2}.", v1, v2, v1 + v2);
        }
    }
}
