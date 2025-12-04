/*
Factory Method Example in C#:
--------------------------------
✔ You have a Product Interface
✔ You have Concrete Products
    SmsNotification, EmailNotification, PushNotification
✔ You have a Creator (abstract class) with a Factory Method
✔ Concrete Creators
    EmailNotificationCreator, SmsNotificationCreator, PushNotificationCreator

*/
public interface INotification
{
    void Send(string message);
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sms Sent message: {message}.");
    }
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Sent message: {message}.");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"PushNotification Sent message: {message}.");
    }
}

public abstract class INotificationCreater
{
    public abstract INotification NotificationCreator(string message);
    public void SendNotification(string message)
    {
        INotification notification = NotificationCreator(message);
        notification.Send(message);
    }
}

public class SmsNotificationCreator : INotificationCreater
{
    public override INotification NotificationCreator(string message)
    {
        return new SmsNotification();
    }
}

public class EmailNotificationCreator : INotificationCreater
{
    public override INotification NotificationCreator(string message)
    {
        return new EmailNotification();
    }
}

public class PushNotificationCreator : INotificationCreater
{
    public override INotification NotificationCreator(string message)
    {
        return new PushNotification();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotificationCreater notificationCreater1 = new EmailNotificationCreator();
        notificationCreater1.SendNotification("Email");

        INotificationCreater notificationCreater2 = new SmsNotificationCreator();
        notificationCreater2.SendNotification("Sms");

        INotificationCreater notificationCreater3 = new PushNotificationCreator();
        notificationCreater3.SendNotification("Push Message");
    }
}


