using System;
using System.Collections;
using System.Linq;

namespace NonGenericCollections
{
    class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over ArrayList *****");
            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"},
                8
            };
            // Transform ArrayList into an IEnumerable<T>-compatible type.
            // Filters out anything except Car.
            var myCarsEnum = myCars.OfType<Car>();
            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum
                           where c.Speed > 55
                           select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            // Can cast explicitly with special syntax
            // but it will throw Exception if cast fails
            var anotherFastCars = from Car c in myCars
                                  where c.Speed > 55
                                  select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
    }
}
