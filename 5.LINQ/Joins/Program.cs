using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joins
{
    class Car
    {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }
    }

    class Ride
    {
        public DateTime Date;
        public int Length;
        public string CarName;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>() {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            List<Ride> rides = new List<Ride> {
                new Ride{ CarName = "Henry", Date = new DateTime(2016, 12, 1), Length = 1000},
                new Ride{ CarName = "Henry", Date = new DateTime(2016, 11, 5), Length = 2000},
                new Ride{ CarName = "Daisy", Date = new DateTime(2016, 12, 10), Length = 10000},
                new Ride{ CarName = "Mary", Date = new DateTime(2016, 12, 10), Length = 3000},
                new Ride{ CarName = "Daisy", Date = new DateTime(2016, 10, 10), Length = 10000},
                new Ride{ CarName = "Daisy", Date = new DateTime(2016, 9, 10), Length = 10000},
            };

            // find the rides for every car
            var query = from car in myCars
                        join ride in rides
                        on car.PetName equals ride.CarName
                        select new { Car = car.PetName, Date = ride.Date};
            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.Car, entry.Date);
            }
            Console.WriteLine();

            // Find number of rides for every car
            var joinedQuery = from car in myCars
                              join ride in rides
                              on car.PetName equals ride.CarName
                              into joined
                              select new { Car = car.PetName, Count = joined.Count() };
            foreach (var grouped in joinedQuery)
            {
                Console.WriteLine("{0:d}: {1}", grouped.Car, grouped.Count);
            }
            Console.WriteLine();

            // Cartesian product
            // could be useful to read logs for example
            //var query = from file in Directory.GetFiles(logDirectory, "*.log")
            //            from line in ReadLines(file)
            //            let entry = new LogEntry(line)
            //            where entry.Type == EntryType.Error
            //            select entry;
            var cQuery = from left in myCars
                         from right in rides
                         select new { Left = left.PetName, Right = right.Date };
            foreach (var pair in cQuery)
            {
                Console.WriteLine("Left={0}; Right={1}",
                pair.Left, pair.Right);
            }
            Console.WriteLine();

            // Grouping
            var groupQuery = from ride in rides
                             group ride by ride.CarName;
            foreach (var entry in groupQuery)
            {
                Console.WriteLine(entry.Key);
                foreach (var ride in entry)
                {
                    Console.WriteLine(" ({0}) {1}", ride.Date, ride.Length);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // Continuing a grouping with another projection
            var cgroupQuery = from ride in rides
                              group ride by ride.CarName into grouped
                              select new { Car = grouped.Key, Count = grouped.Count() } into result
                              orderby result.Count descending
                              select result;
            foreach (var entry in cgroupQuery)
            {
                Console.WriteLine("{0} {1}", entry.Car, entry.Count);
            }
        }
    }
}
