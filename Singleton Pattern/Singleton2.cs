
namespace Singleton_Pattern;

public sealed class Singleton2
{
    private static readonly Singleton2 _instance = new Singleton2();
    public static Singleton2 Instance => _instance;
    // Private constructor to prevent instantiation from outside
    private Singleton2() {
        Console.WriteLine("Created object Singleton2");
    }
}
