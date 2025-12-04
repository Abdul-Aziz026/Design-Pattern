
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

public class House
{
    public bool HasWalls { get; set; }
    public bool HasDoors { get; set; }
    public bool HasWindows { get; set; }
    public bool HasRoof { get; set; }
    public bool HasSwimmingPool { get; set; }

    public override string ToString()
    {
        return $"House [Walls={HasWalls}, Doors={HasDoors}, Windows={HasWindows}, Roof={HasRoof}, Pool={HasSwimmingPool}]";
    }
}

public interface IHouseBuilder
{
    IHouseBuilder BuildWalls();
    IHouseBuilder BuildDoors();
    IHouseBuilder BuildWindows();
    IHouseBuilder BuildRoof();
    IHouseBuilder BuildSwimmingPool();
    House GetHouse();
}

public class HouseBuilder : IHouseBuilder
{
    private House house = new House();
    public IHouseBuilder BuildDoors()
    {
        house.HasDoors = true;
        return this;
    }

    public IHouseBuilder BuildRoof()
    {
        house.HasRoof = true;
        return this;
    }

    public IHouseBuilder BuildSwimmingPool()
    {
        house.HasSwimmingPool = true;
        return this;
    }

    public IHouseBuilder BuildWalls()
    {
        house.HasWalls = true;
        return this;
    }

    public IHouseBuilder BuildWindows()
    {
        house.HasWindows = true;
        return this;
    }

    public House GetHouse()
    {
        return house;
    }
}


public class  Program
{
    public static void Main(string[] args)
    {
        var simpleHouse = new HouseBuilder()
            .BuildWalls()
            .BuildDoors()
            .BuildWindows()
            .BuildRoof()
            .GetHouse();

        Console.WriteLine("simple house:-------");
        Console.WriteLine(simpleHouse);
        Console.WriteLine(simpleHouse.HasRoof);
        Console.WriteLine();

        var fancyHouse = new HouseBuilder()
            .BuildWalls()
            .BuildDoors()
            .BuildWindows()
            .BuildRoof()
            .BuildSwimmingPool()
            .GetHouse();

        Console.WriteLine("fancy house:--------");
        Console.WriteLine(fancyHouse);

    }
}