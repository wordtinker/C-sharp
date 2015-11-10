using System;

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
    // This car can send these events.
    public event EventHandler<CarEventArgs> Exploded;
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
        c1.AboutToBlow += delegate(object sender, CarEventArgs e)
        {
            Console.WriteLine("The car is {0}", c1); // Can access enclosing scope variables
            Console.WriteLine("=> Critical Message from Car: {0}", e.msg);
        };
        c1.AboutToBlow += delegate(object sender, CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        };

        EventHandler<CarEventArgs> d = delegate(object sender, CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        };
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
}
