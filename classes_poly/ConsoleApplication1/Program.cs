using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class ComputingDevice
    {
        private string name;
        public ComputingDevice(string nam) { name = nam; }
        public virtual void AcceptInput()
        {
            Console.WriteLine("Configuring common tasks...");
        }
    }

    class Laptop: ComputingDevice
    {
        public Laptop(string name) : base(name) { }
        public override void AcceptInput()
        {
            base.AcceptInput();
            Console.WriteLine("Configuring Laptop");
        }
    }

    class Tablet: ComputingDevice
    {
        public Tablet(string name) : base(name) { }
        public override void AcceptInput()
        {
            base.AcceptInput();
            Console.WriteLine("Configuring Tablet");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<ComputingDevice> devices = new List<ComputingDevice>();
            devices.Add(new Laptop("Dell"));
            devices.Add(new Tablet("Asus")); // polymorphism

            foreach (ComputingDevice device in devices)
            {
                device.AcceptInput();  // resolved at runtime
            }

        }
    }
}
