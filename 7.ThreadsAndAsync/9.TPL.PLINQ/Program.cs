using System;
using System.Diagnostics;
using System.Linq;

namespace PLINQ
{
    class Benchmark
    {
        static public void Run(string description, int iterations, Action func)
        {
            // Really naive approach to benchmarking
            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect(); // Will put finalizers into separate thread
            GC.WaitForPendingFinalizers(); // They are on separate thread
            GC.Collect(); // Again clean up after finalizers

            watch.Start();
            for (int i = 0; i < iterations; i++)
                func();

            watch.Stop();
            Console.WriteLine(description);
            Console.WriteLine("Ran {0:N0} iterations in {1}ms\n", iterations,
                watch.Elapsed.TotalMilliseconds);
        }
    }

    class Program
    {
        static void AsSingle()
        {
            //Console.WriteLine();
            var source = Enumerable.Range(100, 20000);
            // Result sequence might be out of order.
            var query = from num in source
                        where num % 10 == 0
                        select num;
            // Process result sequence in parallel
            foreach (var item in query)
            {
                // Do nothing
            }
        }

        static void AsParallel()
        {
            //Console.WriteLine();
            var source = Enumerable.Range(100, 20000);
            // Result sequence might be out of order.
            // Cancellation token could be used here
            var parallelQuery = from num in source.AsParallel()
                                where num % 10 == 0
                                select num;
            // Process result sequence in parallel
            parallelQuery.ForAll((e) => { /*DoNothing*/ });
        }

        static void Main(string[] args)
        {
            Benchmark.Run("As Single", 10000, AsSingle);
            Benchmark.Run("As Parallel", 10000, AsParallel);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
