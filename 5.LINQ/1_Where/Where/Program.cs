using System;
using System.Collections.Generic;
using System.Linq;

namespace Where
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
        static void Print<T>(IEnumerable<T> seq)
        {
            foreach (T x in seq)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        static List<Car> GetCars()
        {
            return new List<Car>() {
                new Car{ PetName = "Daisy2", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };
        }

        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // Can filter on element value
            var lowNums = from n in numbers
                          where n < 5
                          select n;
            Print(lowNums);
            // Can filter on element attribute
            var fastCars = from c in GetCars()
                           where c.Speed >= 55
                           select c.PetName;
            Print(fastCars);
            // Can filter on multiple conditions
            // can use multiple where
            // will be translated into where c.Speed >= 55 && c.Make == "BMW"
            var fasterCars = from c in GetCars()
                           where c.Speed >= 55
                           where c.Make == "BMW"
                           select c.PetName;
            Print(fasterCars);
            // Indexed where
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            // returns digits whose name is shorter than their value.
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            Print(shortDigits);
        }
    }
}
