using System;
using System.Threading;

namespace DelegateCall
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void SyncCall()
        {
            Console.WriteLine("***** Sync Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Invoke Add() in a synchronous manner.
            BinaryOp b = new BinaryOp(Add);
            // Could also write b.Invoke(10, 10);
            int answer = b(10, 10);
            // These lines will not execute until
            // the Add() method has completed.
            Console.WriteLine("Doing more work in Main()!");
            Console.WriteLine("10 + 10 is {0}.", answer);
        }

        static void AsyncCall()
        {
            Console.WriteLine("***** Async Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Invoke Add() in a asynchronous manner.
            // but it is still synchronous call, we are waiting till endInvoke resolves.
            BinaryOp b = new BinaryOp(Add);

            IAsyncResult res = b.BeginInvoke(10, 10, null, null);

            Console.WriteLine("Doing more work in Main()!");

            //Obtain results from Add
            int answer = b.EndInvoke(res);
            Console.WriteLine("10 + 10 is {0}.", answer);
        }

        static void WaitCall()
        {
            Console.WriteLine("***** Async Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Invoke Add() in a asynchronous manner.
            BinaryOp b = new BinaryOp(Add);

            IAsyncResult res = b.BeginInvoke(10, 10, null, null);

            //while (!res.IsCompleted)
            //{
            //    Console.WriteLine("Doing more work in Main()!");
            //    Thread.Sleep(1000);
            //}
            while (!res.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in Main()!");
            }

            //Obtain results from Add
            int answer = b.EndInvoke(res);
            Console.WriteLine("10 + 10 is {0}.", answer);
        }

        static void Main(string[] args)
        {
            SyncCall();
            AsyncCall();
            WaitCall();
        }
        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
