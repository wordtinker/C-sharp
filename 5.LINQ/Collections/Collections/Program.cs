using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
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
        static void GetFastCars(List<Car> myCars)
        {
            var fastCars = from c in myCars
                           where c.Speed > 55
                           select c;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast", car.PetName);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
            GetFastCars(myCars);
            Console.ReadLine();
        }
    }
}
