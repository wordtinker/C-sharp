using System;
using System.IO;
using System.Text;

namespace Watching
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\_test\photos\";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Created += (source, e) => Console.WriteLine("{0} -- {1}", e.FullPath, e.ChangeType);
            watcher.Changed += (source, e) => Console.WriteLine("{0} -- {1}", e.FullPath, e.ChangeType);
            watcher.Deleted += (source, e) => Console.WriteLine("{0} -- {1}", e.FullPath, e.ChangeType);
            watcher.Renamed += (source, e) => Console.WriteLine("{0} -- {1}", e.FullPath, e.ChangeType);
            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;

            ReadAndWrite();

            // Wait for the user to quit the program.
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q')
                ;

        }

        private static void ReadAndWrite()
        {
            FileInfo f = new FileInfo(@"C:\_test\photos\test.txt");
            //FileStream fs = f.Create();
            //fs.Close();
            using (FileStream fs = f.Create())
            {
                Console.WriteLine("The file has been created.");
            }

            using (FileStream fs2 = f.Open(FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            {
                Console.WriteLine("The file has been opened.");
            }

            // Obtain a FileStream object.
            using (FileStream fStream = File.Open(@"C:\_test\photos\test.txt",
            FileMode.Create))
            {
                // Encode a string as an array of bytes.
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Write byte[] to file.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // Reset internal position of stream.
                fStream.Position = 0;
                // Read the types from file and display to console.
                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }
                // Display decoded messages.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }

            // Get a StreamWriter and write string data. Easier way
            using (StreamWriter writer = File.CreateText(@"C:\_test\photos\test.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; i++)
                    writer.Write(i + " ");
                // Insert a new line.
                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText(@"C:\_test\photos\test.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
