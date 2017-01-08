using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCombinators
{
    class Program
    {
        static async Task<int> Delay1() { await Task.Delay(1000); return 1; }
        static async Task<int> Delay2() { await Task.Delay(2000); return 2; }
        static async Task<int> Delay3() { await Task.Delay(30000); return 3; }

        static void Main(string[] args)
        {
            DoAll().Wait();
            Do().Wait();
            try
            {
                 DoWithTimeout().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }

        static async Task Do()
        {
            // Task race
            Task<int> winningTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
            Console.WriteLine("Done");
            Console.WriteLine("Result is {0}", await winningTask);
        }

        static async Task DoWithTimeout()
        {
            // Simple timeout implementation 
            Task<int> task = Delay3();
            Task winner = await Task.WhenAny(task, Task.Delay(5000));            if (winner != task) throw new TimeoutException();            Console.WriteLine("Result is {0}", await task);        }

        static async Task DoAll()
        {
            int[] results = await Task.WhenAll(Delay1(), Delay2(), Delay3());
            Console.WriteLine("Done");
            Console.WriteLine("Result is {0}", results.Sum());
        }
    }
}
