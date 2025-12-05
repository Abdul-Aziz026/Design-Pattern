
// implement IFood interface
public interface IFood {
    string GetDescription();
    double GetCost();
}


// implement Pizza class
public class Pizza : IFood {
    public string GetDescription() {
        return "Pizza";
    }
    public double GetCost() {
        return 8.0;
    }
}


// implement FoodDecorator abstract class
public class FoodDecorator(IFood food) : IFood
{
    public double GetCost() => food.GetCost();
    public string GetDescription() => food.GetDescription();
}


// implement CheeseDecorator class
public class CheeseDecorator(IFood food) : FoodDecorator(food)
{
    public double GetCost() => base.GetCost() + 1.5;

    public string GetDescription() =>
        base.GetDescription() + ", Cheese";
}

// implement SpicesDecorator class
public class SpicesDecorator(IFood food) : FoodDecorator(food)
{
    public double GetCost() => base.GetCost() + 0.5;

    public string GetDescription() =>
        base.GetDescription() + ", Spices";
}

// implement Program class
public class Program
{
    public static void Main(string[] args)
    {
        IFood myPizza = new Pizza();
        Console.WriteLine($"Food Description: {myPizza.GetDescription()} and Cost: {myPizza.GetCost()}");

        var cheese = new CheeseDecorator(myPizza);
        Console.WriteLine($"Food Description: {cheese.GetDescription()} and Cost: {cheese.GetCost()}");

        var spices = new SpicesDecorator(cheese);
        Console.WriteLine($"Food Description: {spices.GetDescription()} and Cost: {spices.GetCost()}");
    }
}