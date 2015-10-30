using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            decimal[] prices = new decimal[2];
            prices[0] = 36M;
            prices[1] = 34M;

            int[] items = new int[] { 4, 5 };
            decimal totalPrice = prices[0] * items[0] + prices[1] * items[1];
            Console.WriteLine("Total price is {0:C}", totalPrice);

            // Multidimensional array
            string[,] multi = new string[3, 5];
            for (int i = 0; i < multi.GetLength(0); i++)
            {
                for (int j = 0; j < multi.GetLength(1); j++)
                {
                    var s = String.Format("[{0},{1}]", i, j);
                    multi[i, j] = s;
                    Console.Write(multi[i,j]);
                }
                Console.WriteLine();
            }

            //Proving reference type
            Console.WriteLine("the price is {0}", prices[0]);
            decimal[] new_prices = prices;
            new_prices[0] = 356M;
            Console.WriteLine("the price is {0}", prices[0]);
        }
    }
}
