public class SmtpConnection
{
    public void Connect() => Console.WriteLine("SMTP Connected");
    public void Disconnect() => Console.WriteLine("SMTP Disconnected");
}

public class Authentication
{
    public void Login(string userName, string Password) => Console.WriteLine($"User Authenticated: {userName}");
}

public class EmailBuilder
{
    public void CreateEmail(string to, string subject, string body) =>
        Console.WriteLine($"Email Created:\n\nTo: {to}\nSubject: {subject}\n{body}\n");
}

public class EmailSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine("Email Sent");
    }
}

// Facade
public class EmailFacade
{
    private readonly SmtpConnection _smtpConnection;
    private readonly Authentication _authentication;
    private readonly EmailBuilder _emailBuilder;
    private readonly EmailSender _emailSender;
    public EmailFacade()
    {
        _smtpConnection = new SmtpConnection();
        _authentication = new Authentication();
        _emailBuilder = new EmailBuilder();
        _emailSender = new EmailSender();
    }
    public void SendEmail(string to, string subject, string body)
    {
        _smtpConnection.Connect();
        _authentication.Login("admin@gmail.com", "@Alhamdulillah");
        _emailBuilder.CreateEmail(to, subject, body);
        _emailSender.SendEmail(body);
        _smtpConnection.Disconnect();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EmailFacade emailFacade = new EmailFacade();
        emailFacade.SendEmail("azizul@gmail.com", "Test Mail", 
            "Hello dear,\nI am senting you the testing mail...\nbest regards,\nazizur rahmain\n01797399432");
    }
}