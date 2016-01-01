using System;

namespace StructCopy
{
    class Info
    {
        public string Data;
        public Info(string data)
        {
            Data = data;
        }
    }

    struct Point
    {
        public Info Info;
        public string Name;
        public int X;
        public int Y;

        public Point(string info)
        {
            Info = new Info(info);
            Name = "";
            X = 0;
            Y = 0;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point("Some data");
            p1.Name = "MyPoint";
            p1.X = 10;
            p1.Y = 10;
            Console.WriteLine("Data:{3}, Name:{2}, X:{0}, Y:{1}", p1.X, p1.Y, p1.Name, p1.Info.Data);
            // Make an assignment
            Point p2 = p1;
            p2.X = 100;
            p2.Y = 200;
            p2.Name = "New name";
            p2.Info.Data = "New data";
            Console.WriteLine();
            // Reference is passed for fererence types
            // p2.Info.Data will change p1
            // but p2.Name will not change p1
            Console.WriteLine("Data:{3}, Name:{2}, X:{0}, Y:{1}", p1.X, p1.Y, p1.Name, p1.Info.Data);
            Console.WriteLine("Data:{3}, Name:{2}, X:{0}, Y:{1}", p2.X, p2.Y, p2.Name, p2.Info.Data);
        }
    }
}
