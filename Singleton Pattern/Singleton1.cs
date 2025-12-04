
namespace Singleton_Pattern;

public sealed class Singleton1
{
    private static Singleton1? _instance;
    private static readonly object _lock = new();
    // Private constructor to prevent instantiation from outside
    private Singleton1() {
        Console.WriteLine("Created object Singleton1");
    }

    public static Singleton1 GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton1();
                }
            }
        }
        return _instance;
    }
}
