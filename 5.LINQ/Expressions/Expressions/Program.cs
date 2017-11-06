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

            // Getting total
            Console.WriteLine("Total number: {0}", allProducts.Count());
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
