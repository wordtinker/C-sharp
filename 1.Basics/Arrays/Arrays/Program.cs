using System;

namespace Arrays
{
    class Grades
    {
        public int[] grades;

        public Grades(int[] g)
        {
            grades = g; // Very unsafe
        }
    }

    class Program
    {
        static void Main()
        {
            // One dimensional array
            decimal[] prices = new decimal[2];
            prices[0] = 36M;
            prices[1] = 34M;
            
            // Shorter syntax
            int[] items = new int[] { 4, 5 };
            decimal totalPrice = prices[0] * items[0] + prices[1] * items[1];
            Console.WriteLine("Total price is {0:C}", totalPrice);
            
            // short init syntax
            int[] ints = {1, 2, 3, 4 };


            // Multidimensional array
            string[,] multi = new string[3, 5];
            for (int i = 0; i < multi.GetLength(0); i++)
            {
                for (int j = 0; j < multi.GetLength(1); j++)
                {
                    var s = String.Format("[{0},{1}]", i, j);
                    multi[i, j] = s;
                    Console.Write(multi[i, j]);
                }
                Console.WriteLine();
            }
            // Jagged array
            //  The inner dimensions aren’t specified in the declaration.
            // Unlike a rectangular array, each inner array can be an arbitrary length.
            // Each inner array is implicitly initialized to null rather than an empty array.
            int[][] matrix = new int[10][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[3]; // Create inner array
                for (int j = 0; j < matrix[i].Length; j++)
                    matrix[i][j] = i * 3 + j;
            }

            // Proving reference type
            Console.WriteLine("the price is {0}", prices[0]);
            decimal[] new_prices = prices;
            new_prices[0] = 356M;
            Console.WriteLine("the price is {0}", prices[0]);
            int[] grades = { 1, 2, 3 };
            Grades grader = new Grades(grades);
            Console.WriteLine("The insides of class {0}", grader.grades[0]);
            // Change the initital array
            grades[0] = 100;
            Console.WriteLine("The insides of class {0}", grader.grades[0]);


            Console.WriteLine("=> Working with System.Array.");
            // Initialize items at startup.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
            // Print out names in declared order.
            Console.WriteLine("-> Here is the array:");
            string tmplt = "{0}, ";
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(tmplt, gothicBands[i]);
            }
            Console.WriteLine("\n");
            // foreach enumeration
            foreach (string item in gothicBands)
            {
                Console.Write(tmplt, item);
            }
            Console.WriteLine("\n");
            // and with extension method
            Array.ForEach(gothicBands,band => Console.Write(tmplt, band));
            Console.WriteLine("\n");

            // Searching
            string match = Array.Find(gothicBands, band => band.Contains("B"));
            Console.WriteLine(match);

            // Reverse them...
            Array.Reverse(gothicBands); // Note use of static method
            Console.WriteLine("-> The reversed array");
            // ... and print them.
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Clear out all but the final member.
            Console.WriteLine("-> Cleared out all but one...");
            Array.Clear(gothicBands, 1, 2);
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Print a name.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();

        }
    }
}
