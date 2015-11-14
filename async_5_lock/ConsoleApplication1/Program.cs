using System;
using System.Threading;

namespace ConsoleApplication1
{
    public class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            // Use private lock tocken
            lock (threadLock) // wrapper around Monitor class, use that for more control
                              // use System.Threading.Interlocked for atomic safe operations
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0}, ", i);
                    Thread.Sleep(500);
                }
                Console.WriteLine(); 
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Synchronizing Threads *****\n");
            Printer p = new Printer();
            // Make 10 threads that are all pointing to the same
            // method on the same object.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }
            // Now start each one.
            foreach (Thread t in threads)
                t.Start();
            Console.ReadLine();
        }
    }
}
