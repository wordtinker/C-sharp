using System;
using System.Collections;

class Car
{
    public string Name { get; set;}

    public Car() { }
    public Car (string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return string.Format("{0}:{1}", base.ToString(), Name);
    }
}

class Garage: IEnumerable
{
    private Car[] cars = new Car[4];

    public Garage()
    {
        cars[0] = new Car("Rusty");
        cars[1] = new Car("Clunker");
        cars[2] = new Car("Zippy");
        cars[3] = new Car("Fred");
    }

    // IEnumerable

    //public IEnumerator GetEnumerator()
    //{
    //    return cars.GetEnumerator(); // Simple way
    //}

    public IEnumerator GetEnumerator()
    {
        foreach (Car car in cars)
        {
            yield return car;  // with yield keyword
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();

        foreach (Car c in garage)
        {
            foreach (Car cc in garage)
            {
                Console.WriteLine(cc);
            }
        }
    }
}
