/*
 * 
 * Factory Pattern is a design pattern where you don’t create objects using new directly.
 * Instead, you ask a Factory class to create the object for you.
 * 
 */



// Product Interface
public interface ICar
{
    void Drive();
}

// Concrete Products
public class BMW : ICar
{
    public void Drive()
    {
        Console.WriteLine("Driving BMW...");
    }
}

public class Tesla : ICar
{
    public void Drive()
    {
        Console.WriteLine("Driving Tesla...");
    }
}

public class Audi : ICar
{
    public void Drive()
    {
        Console.WriteLine("Driving Audi...");
    }
}

// Factory Class
public static class CarFactory
{
    public static ICar CreateCar(string type)
    {
        return type switch
        {
            "BMW" => new BMW(),
            "Tesla" => new Tesla(),
            "Audi" => new Audi(),
            _ => throw new Exception("Unknown car type")
        };
    }
}

// Program (Main)
public class Program
{
    public static void Main()
    {
        ICar car1 = CarFactory.CreateCar("BMW");
        car1.Drive();

        ICar car2 = CarFactory.CreateCar("Tesla");
        car2.Drive();

        ICar car3 = CarFactory.CreateCar("Audi");
        car3.Drive();
    }
}
