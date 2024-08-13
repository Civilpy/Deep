// baz bebin 

/*
 we can use the idea of composition to create an object
 that is made up of other objects!
 "is made up of" relationship(whereas inheritance 
 model an "is a" relationship)
 
 lets use composition to model a desktop computer!
we'll need :
- a case
- a motherboard
- a power supply
- a hard Drive
-  some Ram
- a graphic card
 */


Computer myComputer = new Computer(
    new Case(),
    new Motherboard(),
    new PowerSupply(),
    new HardDrive(sizInTb: 16),
    new Ram(sizInTb: 64),
    new GraphicCard());
myComputer.PowerOn();

public sealed class Case
{
    public void PressPowerButton()
    {
        Console.WriteLine("Power button pressed");
    }
}

public sealed class Motherboard
{
    public void Boot()
    {
        Console.WriteLine("Booting...");
    }
}


public sealed class PowerSupply
{
    public void TurnOn()
    {
        Console.WriteLine("Power supply turned on");
    }
}

public sealed class HardDrive
{
    private readonly int _sizeInTb;

    public HardDrive(int sizInTb)
    {
        _sizeInTb = sizInTb;
    }
    public void ReadData()
    {
        Console.WriteLine(
            $"Reading data from hard drive with capacity of {_sizeInTb} GB");
    }
}
public sealed class Ram
{
    private readonly int _sizeInTb;

    public Ram(int sizInTb)
    {
        _sizeInTb = sizInTb;
    }
    public void Load()
    {
        Console.WriteLine(
            $"Reading data from hard drive with capacity of {_sizeInTb} GB");
    }
}

public sealed class GraphicCard
{
    public void Render()
    {
        Console.WriteLine("Rendering graphics");
    }
}

//public sealed class Computer
//{
//    private readonly Case _thecase;
//    private readonly Motherboard _motherboard;
//    private readonly PowerSupply _powerSupply;
//    private readonly HardDrive _hardrive;
//    private readonly GraphicCard _graphicCard;
//    private readonly Ram _ram;

//    public Computer(
//        Case thecase,
//        Motherboard motherboard,
//        PowerSupply powerSupply,
//        HardDrive hardDrive,
//        Ram ram,
//        GraphicCard graphicCard)
//    {
//    }
//    public 

   

//}


public sealed class Computer // shabihe Record has
{
    private readonly Case _thecase;
    private readonly Motherboard _motherboard;
    private readonly PowerSupply _powerSupply;
    private readonly HardDrive _hardrive;
    private readonly Ram _ram;
    private readonly GraphicCard _graphicCard;
   public Computer(Case theCase,
                            Motherboard motherboard,
                            PowerSupply powerSupply,
                            HardDrive hardDrive,
                            Ram ram,
                            GraphicCard graphicCard
       )
    {
        _thecase = theCase;
        _motherboard = motherboard;
        _powerSupply = powerSupply;
        _hardrive = hardDrive;
        _ram = ram;
        _graphicCard = graphicCard;

    }
    public void PowerOn()
    {
        _thecase.PressPowerButton();
        _powerSupply.TurnOn();
        _motherboard.Boot();
        _ram.Load();
        _hardrive.ReadData();
        _graphicCard.Render();
    }
}
