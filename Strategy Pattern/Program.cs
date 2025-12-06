/*
 * The Strategy design pattern is a behavioral design pattern that enables selecting an algorithm or behavior at runtime.
 * It is based on the principle of composition over inheritance.
 */
public interface IFlyBehavior
{
    void Fly();
}

public class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I'm flying with wings!");
    }
}

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I can't fly.");
    }
}

public abstract class Duck
{
    protected IFlyBehavior _flyBehavior;
    public abstract void Display();
}

public class MountainDuck : Duck
{
    public MountainDuck()
    {
        _flyBehavior = new FlyWithWings();
    }
    public override void Display()
    {
        Console.WriteLine("I'm a Mountain Duck.");
        _flyBehavior.Fly();
    }
}

public class VillageDuck : Duck
{
    public VillageDuck()
    {
        _flyBehavior = new FlyNoWay();
    }
    public override void Display()
    {
        Console.WriteLine("I'm a Village Duck.");
        _flyBehavior.Fly();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Duck mountainDuck = new MountainDuck();
        mountainDuck.Display();

        Console.WriteLine();
        Duck villageDuck = new VillageDuck();
        villageDuck.Display();
    }
}