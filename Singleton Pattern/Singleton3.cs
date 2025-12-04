
namespace Singleton_Pattern;

public sealed class Singleton3
{
    private static readonly Lazy<Singleton3> _instance = new Lazy<Singleton3>(new Singleton3());
    public static Singleton3 Instance => _instance.Value;
    // Private constructor to prevent instantiation from outside
    private Singleton3()
    {
        Console.WriteLine("Created object Singleton2");
    }
}


