using System;

class Tablet: ComputingDevice
{
    private int screenSize; //only this class
    public Tablet(int size)
    {
        screenSize = size;
    }
    public string CaseColor
    {
        get
        {
            return this.caseColor;
        }
    }
    public override void Read()
    {
        Console.WriteLine("Reading finger traces.");
    }
}
