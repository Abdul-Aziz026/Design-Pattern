/*
 * 
 * Don’t let objects talk to each other directly. Instead, let a mediator object manage all communication between them.
 * So objects become less dependent, more decoupled, and the system becomes easier to maintain.
 * 
 * Example:-
 * ✈ Planes never talk to each other directly.
 * 📡 All communication goes through the control tower (mediator).
 * who can land, who can take off and who must wait
 * 
*/

using System.Reflection.Metadata;

public interface IMediator
{
    void SendMessage(string message, string senderUserName);
    void Register(User user);
}

public class User
{
    private readonly IMediator _mediator;
    public string Name { get; }
    public User(IMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} Send message to everyone: {message}");
        _mediator.SendMessage($"{Name}: {message}", Name);
    }
    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received: {message}");
    }
}

public class ChatRoom : IMediator
{
    private List<User> _users = new();
    public void Register(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, string senderUserName)
    {
        foreach (var user in _users)
        {
            if (!user.Name.Equals(senderUserName))
            {
                user.ReceiveMessage(message);
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IMediator chatRoom = new ChatRoom();

        var user1 = new User(chatRoom, "Alice");
        var user2 = new User(chatRoom, "Bob");
        var user3 = new User(chatRoom, "Charlie");
        var user4 = new User(chatRoom, "Diana");

        chatRoom.Register(user1);
        chatRoom.Register(user2);
        chatRoom.Register(user3);
        chatRoom.Register(user4);

        user1.Send("Hello, everyone!");
    }
}

