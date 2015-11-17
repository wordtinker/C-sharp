using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication1
{
    [Serializable]
    class UserPrefs
    {
        public string WindowsColor;
        public int FontSize;

        [NonSerialized]
        public int somevalue = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserPrefs userData = new UserPrefs { WindowsColor = "Yellow", FontSize = 14 };

            BinaryFormatter bf = new BinaryFormatter();
            
            using(Stream fstream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                bf.Serialize(fstream, userData);
            }

            UserPrefs newPrefs = new UserPrefs();
            using(Stream rsteam = File.OpenRead("user.dat"))
            {
                newPrefs = (UserPrefs)bf.Deserialize(rsteam);
            }

            Console.WriteLine("{0} {1}",newPrefs.WindowsColor, newPrefs.FontSize);
        }
    }
}
