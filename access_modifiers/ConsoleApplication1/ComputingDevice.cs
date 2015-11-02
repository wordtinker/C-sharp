using System;

class ComputingDevice
{
    protected string caseColor = "black"; // this and child classes
    public virtual void Read() //anyone
    {
        Console.WriteLine("Reading key strokes");
    }
}

