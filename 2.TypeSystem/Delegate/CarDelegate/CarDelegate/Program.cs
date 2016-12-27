using System;

namespace CarDelegate
{
    public class Car
    {
        // delegate
        public delegate void CarEngineHandler(string msgForCaller);

        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool carIsDead;
        // List of delegate handlers
        private CarEngineHandler listOfHandlers;
        // Class constructors.
        public Car() { MaxSpeed = 100; }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        // function to register delegate
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (carIsDead)
            {
                // Pre 6.0 Way
                // In multithreaded scenarios, you need to assign
                // the delegate to a temporary variable before testing and invoking
                // it to avoid a thread - safety error:
                // var temp = listOfHandlers;
                // if (temp != null)
                // {
                //     temp("Sorry, this car is dead...");
                // }
                listOfHandlers?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Is this car "almost dead"?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
                }
            }

            if (CurrentSpeed >= MaxSpeed)
                carIsDead = true;
            else
                listOfHandlers?.Invoke($"CurrentSpeed = {CurrentSpeed}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // First, make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);
            // Now, tell the car which method to call
            // when it wants to send us messages.
            c1.RegisterWithCarEngine(OnCarEngineEvent);
            c1.RegisterWithCarEngine(OnCarEngineEvent2);
            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }
        // This is the target for incoming events.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}
