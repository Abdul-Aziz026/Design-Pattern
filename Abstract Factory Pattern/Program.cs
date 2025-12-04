/*
Abstract Factory Pattern Example in C#:
----------------------------------------
✔ Product Interfaces
    Chair, Table → product families.

✔ Concrete Products
    ModernChair, ModernTable
    VictorianChair, VictorianTable

✔ Factory Interface
    FurnitureFactory → creates related objects (Chair + Table).

✔ Concrete Factories
    ModernFurnitureFactory → produces modern Chair + Table
    VictorianFurnitureFactory → produces victorian Chair + Table

✔ Client Code
    Main() works with only the factory interface, not concrete classes.


# Why this is NOT just Factory Method?
Factory Method = one method → one product
Abstract Factory = multiple factory methods → related product family

*/

public interface Chair
{
    void sitOn();  // Common functionality for all chairs
}

public interface Table
{
    void use();    // Common functionality for all tables
}

// Concrete implementation of Modern Chair
public class ModernChair : Chair
{
    public void sitOn()
    {
        Console.WriteLine("Sitting on a modern chair!");
    }
}

// Concrete implementation of Modern Table
public class ModernTable : Table
{
    public void use()
    {
            Console.WriteLine("Using a modern table!");
    }
}

// Concrete implementation of Victorian Chair
public class VictorianChair : Chair
{
    public void sitOn()
    {
        Console.WriteLine("Sitting on a Victorian chair!");
    }
}

// Concrete implementation of Victorian Table...
public class VictorianTable : Table
{
    public void use()
    {
        Console.WriteLine("Using a victorian table!");
    }
}

public interface FurnitureFactory
{
    Chair createChair();  // Method to create a Chair
    Table createTable();  // Method to create a Table
}

// Factory for creating modern furniture...
public class ModernFurnitureFactory : FurnitureFactory
{
    public Chair createChair()
    {
        return new ModernChair(); // Create a modern chair
    }

    public Table createTable()
    {
        return new ModernTable(); // Create a modern table
    }
}

public class VictorianFurnitureFactory : FurnitureFactory
{
    public Chair createChair()
    {
        return new VictorianChair();
    }

    public Table createTable()
    {
        return new VictorianTable();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create modern furniture using the ModernFurnitureFactory
        FurnitureFactory modernFactory = new ModernFurnitureFactory();
        Chair modernChair = modernFactory.createChair();
        Table modernTable = modernFactory.createTable();

        // Use the modern furniture
        modernChair.sitOn();
        modernTable.use();

        // Create Victorian furniture using the VictorianFurnitureFactory
        FurnitureFactory victorianFactory = new VictorianFurnitureFactory();
        Chair victorianChair = victorianFactory.createChair();
        Table victorianTable = victorianFactory.createTable();

        // Use the Victorian furniture
        victorianChair.sitOn();
        victorianTable.use();
    }
}


