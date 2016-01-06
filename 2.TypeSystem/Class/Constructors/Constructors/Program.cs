using System;

namespace Constructors
{
    class Car
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;

        // When custom constructor is declared, 
        // default constructor is lost.

        // A custom default constructor.
        public Car()
            : this("Chuck", 10) {} // Constructor chaining
        // Here, currSpeed will receive the
        // default value of an int (zero).
        public Car(string pn)
        {
            petName = pn;
        }
        // Let caller set the full state of the Car.
        public Car(string pn, int cs)
        {
            this.petName = pn; // Use of "this"
            this.currSpeed = cs;
        }

        public void PrintState()
        {
            Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);
        }
    }

    class OptCar
    {
        // The 'state' of the Car.
        public string petName;
        public int currSpeed;

        // One Constructor instead of three.
        public OptCar(string pn = "Chuck", int cs = 10)
        {
            petName = pn;
            currSpeed = cs;
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");
            // Make a Car called Chuck going 10 MPH.
            Car chuck = new Car();
            chuck.PrintState();
            // Make a Car called Mary going 0 MPH.
            Car mary = new Car("Mary");
            mary.PrintState();
            // Make a Car called Daisy going 75 MPH.
            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();
        }
    }
}
