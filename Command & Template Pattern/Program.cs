
public interface ICommandConsumer
{
    string CommandName { get; }
    Task DoExecute();
    Task Execute();
}

public abstract class CommandConsumerBase : ICommandConsumer
{
    public string CommandName { get; protected set; }
    public abstract Task DoExecute();
    public async Task Execute()
    {
        await DoExecute();
    }
}

public class CreateUserCommandConsumer : CommandConsumerBase
{
    public CreateUserCommandConsumer()
    {
        CommandName = "CreateUser";
    }
    public override async Task DoExecute()
    {
        // Logic to create a user
        await Task.Delay(1000);
        Console.WriteLine("User created successfully.");
    }
}

public class DeleteUserCommandConsumer : CommandConsumerBase
{
    public DeleteUserCommandConsumer()
    {
        CommandName = "DeleteUser";
    }
    public override async Task DoExecute()
    {
        // Logic to delete a user
        await Task.Delay(1000);
        Console.WriteLine("User deleted successfully.");
    }
}

public class Publisher
{
    public void Publish(ICommandConsumer commandConsumer)
    {
        Console.WriteLine($"Publishing command: {commandConsumer.CommandName}");
        // this is fake publisher logic
        commandConsumer.Execute();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Publisher publisher = new Publisher();
        ICommandConsumer createUserCommand = new CreateUserCommandConsumer();
        publisher.Publish(createUserCommand);

        ICommandConsumer deleteUserCommand = new DeleteUserCommandConsumer();
        publisher.Publish(deleteUserCommand);
    }
}


