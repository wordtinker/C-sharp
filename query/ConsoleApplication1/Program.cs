using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void QueryOverStringsNoLINQ()
    {
        // Assume we have an array of strings.
        string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

        string[] subset = Array.FindAll(currentVideoGames, i => i.Contains(" "));
        Array.Sort(subset);

        foreach (string s in subset)
        {
            Console.WriteLine("Item: {0}", s);
        }
        Console.WriteLine();

        //Change some data in the array
        currentVideoGames[0] = "Morrowind 2";

        foreach (string s in subset)
        {
            Console.WriteLine("Item: {0}", s);
        }
        Console.WriteLine();

    }

    static void QueryOverStrings()
    {
        // Assume we have an array of strings.
        string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

        // Build a query expression to find the items in the array
        // that have an embedded space.
        var subset = from g in currentVideoGames
                                     where g.Contains(" ")
                                     orderby g select g;

        foreach (string s in subset)
        {
            Console.WriteLine("Item: {0}", s);
        }
        Console.WriteLine();

        //Change some data in the array
        currentVideoGames[0] = "Morrowind 2";  // it will change LINQ data!!
        foreach (string s in subset)
        {
            Console.WriteLine("Item: {0}", s);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("***** Fun with LINQ to Objects *****\n");
        QueryOverStringsNoLINQ();
        Console.WriteLine("----- ----- -----");
        QueryOverStrings();
        Console.ReadLine();
    }
}
