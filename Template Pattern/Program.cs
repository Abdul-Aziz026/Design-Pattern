/*
 * Template Method is a behavioral design pattern where
 * you define the skeleton (fixed steps) of an algorithm in a base class,
 * but allow subclasses to change some steps without changing the overall flow.
 * 
 * Resource: https://medium.com/@ravipatel.it/understanding-the-template-design-pattern-in-c-7c3712ed979a
 * 
 */

public abstract class DataProcessor
{
    public void ProcessData()
    {
        ReadData();
        ProcessDataDetails();
        SaveData();
    }
    public abstract void ReadData();
    public abstract void ProcessDataDetails();
    public void SaveData()
    {
        Console.WriteLine("Data saving...\n");
    }
}

public class XmlDataProcessor : DataProcessor
{
    public override void ProcessDataDetails()
    {
        Console.WriteLine("Processing Xml data...");
    }

    public override void ReadData()
    {
        Console.WriteLine("Reading Xml Data...");
    }
}

public class JsonDataProcessor : DataProcessor
{
    public override void ProcessDataDetails()
    {
        Console.WriteLine("Processing Json data...");
    }
    public override void ReadData()
    {
        Console.WriteLine("Reading Json Data...");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DataProcessor xmlProcessor = new XmlDataProcessor();
        xmlProcessor.ProcessData();

        DataProcessor jsonProcessor = new JsonDataProcessor();
        jsonProcessor.ProcessData();
    }
}