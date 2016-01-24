using System;

namespace CarEvent
{
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

    public class Car
    {
        // This delegate works in conjunction with the
        // Car's events.
        //public delegate void CarEngineHandler(object sender, CarEventArgs e);

        // This car can send these events.
        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;
        public event EventHandler<CarEventArgs> Exploded; // dont need to declare delegate at all
        public event EventHandler<CarEventArgs> AboutToBlow;

        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool carIsDead;
        // Class constructors.
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed
                && AboutToBlow != null)
                {
                    AboutToBlow(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);
            // Register event handlers.
            //c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            c1.AboutToBlow += CarIsAlmostDoomed;
            //c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);
            c1.AboutToBlow += CarAboutToBlow;

            //Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploded);
            EventHandler<CarEventArgs> d = CarExploded;
            c1.Exploded += d;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            // Remove CarExploded method
            // from invocation list.
            c1.Exploded -= d;
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        { Console.WriteLine("=> Critical Message from Car: {0}", e.msg); }

        public static void CarExploded(object sender, CarEventArgs e)
        { Console.WriteLine(e.msg); }
    }
}
