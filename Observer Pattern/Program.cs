/*
 * When one object changes, it automatically notifies all other dependent objects.
 * 
 * --------------------------------------------------------------------------*
 * Explain like 6-year-old                                                   |
 * Imagine you have a YouTube channel.                                       |
 * People subscribe to your channel.                                         |
 * When you upload a new video, all subscribers get a notification.          |
 *                                                                           |
 * Here:                                                                     |
 * You (channel) = Subject                                                   |
 * Subscribers = Observers                                                   |
 * New video notification = Update()                                         |
 * --------------------------------------------------------------------------*
 * 
 * 
 * --------------------------------------------------------------------------*
 * Observers don’t keep checking. Subject tells them when something happens. |
 * --------------------------------------------------------------------------*
 * 
 * --------------------------------------------------------------------------*
 * Why we use Observer pattern?                                              |
 * To avoid manual checking or polling                                       |
 * To keep systems loosely coupled                                           |
 * When multiple objects depend on one object’s state                        |
 * Event-driven systems                                                      |
 * --------------------------------------------------------------------------*
 */

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Subscribe(IObserver observer);
    void UbSubscribe(IObserver observer);
    void Notify(string message);
}

public class YouTubeChannel : ISubject
{
    private List<IObserver> observers = new();
    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UbSubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void UploadVideo(string title)
    {
        Console.WriteLine($"New video uploaded on youtube channel...");
        Notify(title);
    }
}

public class User : IObserver
{
    private string name;
    public User(string name)
    {
        this.name = name;
    }
    public void Update(string message)
    {
        Console.WriteLine($"{name} received notification: {message}");
    }
}


public class Program
{
    public static void Main()
    {
        var channel = new YouTubeChannel();

        IObserver user1 = new User("Alice");
        IObserver user2 = new User("Bob");

        channel.Subscribe(user1);
        channel.Subscribe(user2);

        channel.UploadVideo("Design Patterns in C# - Observer Pattern");
        Console.WriteLine();

        channel.UbSubscribe(user1);
        channel.UploadVideo("Understanding SOLID Principles");

    }
}
