/*
 * 
 */





using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

public enum DoorPosition
{
    FrontDriverSide,
    FrontPassengerSide,
    RearDriverSide,
    RearPassengerSide
}

//
// Inheritance
//

public abstract class Vehicle
{

}

//public abstract class Automobile : Vehicle
//{
//    public abstract void StartEngine();

//    public abstract void OpenDoor(DoorPosition doorPosition);
//}

//public abstract class Car : Automobile
//{
//    public override void StartEngine()
//    {
//        Console.WriteLine("car starting  engine 1.8L engine!");
//    }
//}


public abstract class Automobile : Vehicle
{
    private readonly string _engineType;

    public Automobile(string engineType)
    {
        _engineType = engineType;
    }

    public void StartEngine()
    {
        StartEngine(_engineType);
    }
     
    public static void StartEngine(string engineType)
    {
        Console.WriteLine($"starting {engineType} engine!");
    }
}

public abstract class Car : Automobile
{
    public override void StartEngine()
    {
        Console.WriteLine("car starting  engine 1.8L engine!");
    }
}



public class Sedan : Car
{
    public override void OpenDoor(DoorPosition doorPosition)
    {
        Console.WriteLine($"Sedan opening {doorPosition} door!");
    }
}


public class Coupe : Car
{
    public override void OpenDoor(DoorPosition doorPosition)
    {
        if(doorPosition == DoorPosition.RearDriverSide ||
           doorPosition == DoorPosition.RearPassengerSide)
        {
            throw new InvalidCastException("coupes only have doors!");
        }
        Console.WriteLine($"Coupe opening {doorPosition} door!");
    }
}





public class PickupTruck : Automobile
{
    public override void StartEngine()
    {
        Console.WriteLine("Truck starting engine 3.6L engine!");
    }
    public override void OpenDoor(DoorPosition doorPosition)
    {
        if (doorPosition == DoorPosition.RearDriverSide ||
           doorPosition == DoorPosition.RearPassengerSide)
        {
            throw new InvalidCastException("Truck only have two doors!");
        }
        Console.WriteLine($"Truck opening {doorPosition} door!");
    }

}

public class Van : Automobile
{
    public override void StartEngine()
    {
        Console.WriteLine("Van starting engine 3.6L engine!");

    }

    public override void OpenDoor(DoorPosition doorPosition)
    {
        if (doorPosition == DoorPosition.RearDriverSide ||
           doorPosition == DoorPosition.RearPassengerSide)
        {
            throw new InvalidCastException($"Van sliding open {doorPosition}");
        }
        else
        {
        Console.WriteLine($"Van swinging open {doorPosition} door!");
        }
    }
}
