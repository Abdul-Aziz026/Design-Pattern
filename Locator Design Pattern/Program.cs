public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Console logger...");
    }
}

public static class ServiceLocator
{
    private static Dictionary<object, object> _services = new();

    public static void Registor<T>(T service)
    {
        _services.TryAdd(typeof(T), service);
    }

    public static T? GetService<T>()
    {
        try
        {
            return (T)_services[typeof(T)];
        }
        catch (Exception)
        {
            Console.WriteLine($"Service not found...");
            return default(T);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ServiceLocator.Registor<ILogger>(new ConsoleLogger());

        ILogger loggerService = ServiceLocator.GetService<ILogger>();
        loggerService.Log("hello");
    }
}


