using System;
using System.IO;


namespace ConsoleApplication1
{
    class Program
    {
        static void PrintStats(FileInfo file)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("File name: {0}", file.Name);
            Console.WriteLine("File size: {0}", file.Length);
            Console.WriteLine("Creation: {0}", file.CreationTime);
            Console.WriteLine("Attributes: {0}", file.Attributes);
            Console.WriteLine("***************************\n");
        }

        static void PrintStats(DirectoryInfo dir)
        {
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("**************************\n");
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo cwd = new DirectoryInfo(".");
            PrintStats(cwd);

            DirectoryInfo dir2 = new DirectoryInfo(@"C:\_test\photos");
            PrintStats(dir2);
            FileInfo[] files = dir2.GetFiles("*.jpg", SearchOption.AllDirectories);
            //foreach (FileInfo item in files)
            //{
            //    PrintStats(item);
            //}
            foreach (FileInfo item in dir2.EnumerateFiles("*.jpg", SearchOption.AllDirectories)) //same with IEnumerable
            {
                PrintStats(item);
            }

            // List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives(); // Return strings not objects
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
                Console.WriteLine("--> {0} ", s);

            // Get info regarding all drives.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Now print drive stats.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);
                // Check to see whether the drive is mounted.
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            Console.ReadLine();
        }
    }
}
