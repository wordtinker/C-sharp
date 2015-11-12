using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    static void printCount(List<string> cars)
    {
        int g = (from c in cars where c == "BMW" select c).Count();

        Console.WriteLine("The count is {0}", g);
    }

    static void ReverseLINQ(List<string> cars)
    {
        foreach (var item in (from c in cars select c).Reverse())
        {
            Console.WriteLine("Car name is {0}", item);
        }
    }

    static void OrderByLength(List<string> cars)
    {
        foreach (var item in (from c in cars orderby c.Length select c))
        {
            Console.WriteLine("Car name is {0}", item);
        }
    }

    static void DisplayDiff(List<string> myCars, List<string> yourCars)
    {
        var carDiff = (from c in myCars select c)
        .Except(from c2 in yourCars select c2);
        Console.WriteLine("Here is what you don't have, but I do:");
        foreach (var s in carDiff)
            Console.WriteLine(s); // Prints Yugo.
    }

    static void DisplayCommon(List<string> myCars, List<string> yourCars)
    {
        // Get the common members.
        var carIntersect = (from c in myCars select c)
        .Intersect(from c2 in yourCars select c2);
        Console.WriteLine("Here is what we have in common:");
        foreach (string s in carIntersect)
            Console.WriteLine(s); // Prints Aztec and BMW.
    }

    static void DisplayUnion(List<string> myCars, List<string> yourCars)
    {
        // Get the union of these containers.
        var carUnion = (from c in myCars select c)
        .Union(from c2 in yourCars select c2);

        Console.WriteLine("Here is everything:");
        foreach (string s in carUnion)
            Console.WriteLine(s); // Prints all common members.
    }

    static void DisplayConcat(List<string> myCars, List<string> yourCars)
    {
        var carConcat = (from c in myCars select c)
        .Concat(from c2 in yourCars select c2);
        // Prints:
        // Yugo Aztec BMW BMW Saab Aztec.
        foreach (string s in carConcat) //.Distinct will remove duplicates
            Console.WriteLine(s);
    }

    static void Main(string[] args)
    {
        List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
        printCount(myCars);
        Console.WriteLine();

        ReverseLINQ(myCars);
        Console.WriteLine();

        OrderByLength(myCars);
        Console.WriteLine();

        DisplayDiff(myCars, yourCars);
        Console.WriteLine();

        DisplayCommon(myCars, yourCars);
        Console.WriteLine();

        DisplayUnion(myCars, yourCars);
        Console.WriteLine();

        DisplayConcat(myCars, yourCars);
        Console.WriteLine();
    }
}
