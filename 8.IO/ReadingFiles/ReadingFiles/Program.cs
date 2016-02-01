using System;
using System.IO;

namespace ReadingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"c:\data\SampleFile.txt");
            sw.Write(Console.ReadLine());
            sw.Close();

            StreamReader sr = new StreamReader(@"c:\data\SampleFile.txt");
            Console.WriteLine(sr.ReadLine());
            sr.Close();

            // more modern approach
            using (StreamWriter writer = File.CreateText(@"c:\data\SampleFile.txt"))
            {
                string s = Console.ReadLine();
                while (s != "Exit")
                {
                    writer.Write(s + "\n");
                    s = Console.ReadLine();
                }
            }

            using (StreamReader reader = File.OpenText(@"c:\data\SampleFile.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine();
        }
    }
}
