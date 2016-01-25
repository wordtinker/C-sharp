using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }
        public override string ToString()
        {
            return string.Format("Name={0}, Description={1}, Number in Stock={2}",
            Name, Description, NumberInStock);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");
            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo{ Name = "Mac's Coffee",
                                 Description = "Coffee with TEETH",
                                 NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk",
                                 Description = "Milk cow's love",
                                 NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                                 Description = "Bland as Possible",
                                 NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                                 Description = "Cheezy, peppery goodness",
                                 NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                                 Description = "From the tap to your wallet",
                                 NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                                 Description = "Everyone loves pizza!",
                                 NumberInStock = 73}
            };

            // Get everything!
            Console.WriteLine("All product details:");
            var allProducts = from p in itemsInStock
                              select p;

            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }
            // Getting total
            Console.WriteLine("Total number: {0}", allProducts.Count());
            Console.WriteLine();

            Console.WriteLine("The overstock items!");
            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in itemsInStock
                            where p.NumberInStock > 25
                            select p;
            // Print in reverse order
            foreach (ProductInfo c in overstock.Reverse())
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();

            // Get only name and description
            // using anonymous type
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in itemsInStock
                           select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                // Could also use Name and Description properties directly.
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            // Get names of products, alphabetized.
            var subset = from p in itemsInStock
                         orderby p.Name
                         select p;
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();

            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c)
                .Except(from c2 in yourCars select c2);
            // myCars.Except(yourCars) will do the job too
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Prints Yugo.

            // Get the common members.
            var carIntersect = (from c in myCars select c)
                .Intersect(from c2 in yourCars select c2);
            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW.

            // Get the union of these containers.
            var carUnion = (from c in myCars select c)
                .Union(from c2 in yourCars select c2);
            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
            Console.WriteLine();

            var carConcat = (from c in myCars select c)
                .Concat(from c2 in yourCars select c2);
            // Prints:
            // Yugo Aztec BMW BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }
    }
}
