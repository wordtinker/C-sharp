using System;

namespace CommandLineArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Process any incoming args.
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);
            Console.ReadLine();

            // process with foreach
            foreach (string arg in args)
                Console.WriteLine("Arg: {0}", arg);
            Console.ReadLine();

            // Get arguments using System.Environment.
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);
            Console.ReadLine();
        }
    }
}
