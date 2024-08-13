ComposedVehicle composedVehicle = new ComposedVehicle(
    new ConfigurableEngine(1.8f),
    new Dictionary<DoorPosition, IDoor>
    {
        {DoorPosition.FrontDriverSide, new StandardSwingDoor() },
        {DoorPosition.FrontPassengerSide, new StandardSwingDoor() },
        {DoorPosition.RearDriverSide, new StandardSwingDoor() },
        {DoorPosition.RearPassengerSide, new StandardSwingDoor()}
    });


ComposedVehicle composedCoupe = new ComposedVehicle(
    new ConfigurableEngine(1.8f),
    new Dictionary<DoorPosition, IDoor>
    {
        {DoorPosition.FrontDriverSide, new StandardSwingDoor()},
        {DoorPosition.FrontPassengerSide, new StandardSwingDoor()}
    });


ComposedVehicle composedTruck = new ComposedVehicle(
    new V8Engine(),
    new Dictionary<DoorPosition, IDoor>
    {
        {DoorPosition.FrontDriverSide, new StandardSwingDoor() },
        {DoorPosition.FrontPassengerSide, new StandardSwingDoor() }
    });


ComposedVehicle composedPickUpTruck = new ComposedVehicle(
    new V8Engine(),
    new Dictionary<DoorPosition, IDoor>
    {
        {DoorPosition.FrontDriverSide, new StandardSwingDoor() },
        {DoorPosition.FrontPassengerSide, new StandardSwingDoor() },
        {DoorPosition.RearDriverSide, new StandardSwingDoor()},
        {DoorPosition.RearPassengerSide,new StandardSwingDoor()}
    });

// read about these







public interface IEngine
{
    void Start();
}

public class V8Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Big ol' V8 engine starting");
    }
}

public class ConfigurableEngine : IEngine
{
    public readonly float _displacementInLiters;

    public ConfigurableEngine(float displacementInLiters)
    {
        _displacementInLiters = displacementInLiters;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {_displacementInLiters}L engine");
    }
}

public interface IDoor
{
    void Open();
}

public class StandardSwingDoor : IDoor
{
    public void Open()
    {
        Console.WriteLine($"Swinging opening door!");
    }
}

public class SlidingDoor : IDoor
{
    public void Open()
    {
        Console.WriteLine();
    }
}

public sealed class ComposedVehicle
{
    private readonly IEngine _engine;
    private readonly IReadOnlyDictionary<DoorPosition, IDoor> _doors;

    public ComposedVehicle(
        IEngine engine,
        Dictionary<DoorPosition, IDoor> doors)
    {
        _engine = engine;
        _doors = doors;
    }

    public void StartEngine()
    {
        _engine.Start();
    }


    public void OpenDoor(DoorPosition doorPosition)
    {
        if(!_doors.TryGetValue(doorPosition, out IDoor door))
        { 
            throw new InvalidOperationException(
                $"Ther is no door at position {doorPosition}!");

        }
        Console.WriteLine($"Openning {doorPosition} door ...");
        door.Open();
    }

}