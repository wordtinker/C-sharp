using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class ThreeDShape
    {
        public abstract double GetVolume();
    }

    class Sphere : ThreeDShape
    {
        private double radius;

        public Sphere(double r)
        {
            radius = r;
        }

        public override double GetVolume()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(radius, 3);
        }
    }

    class Cube: ThreeDShape
    {
        private double side;

        public Cube(double s)
        {
            side = s;
        }

        public override double GetVolume()
        {
            return Math.Pow(side, 3);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ThreeDShape[] forms = { new Sphere(4), new Cube(8) };
            foreach (var form in forms)
            {
                Console.WriteLine("The volume is {0}", form.GetVolume());
            }

        }
    }
}
