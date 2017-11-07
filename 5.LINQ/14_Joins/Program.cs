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
        }
    }
}
