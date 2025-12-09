public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}";
    }
}

public class CreateUserCommand
{
    public string Name { get; set; }

    public CreateUserCommand(string name)
    {
        Name = name;
    }
}

public class CreateUserCommandHandler
{
    public void Handle(CreateUserCommand request)
    {
        Console.WriteLine($"Create User Handler");
        Console.WriteLine($"User Created: {request.Name}");
        Console.WriteLine();
    }
}

public class GetUserByIdQuery
{
    public int Id { get; set; }
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetUserByIdQueryHandler
{
    public User Handle(GetUserByIdQuery request)
    {
        Console.WriteLine("Query Handler");
        return new User
        {
            Id = request.Id,
            Name = "Azizur"
        };
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var createUserHandler = new CreateUserCommandHandler(); // Create Handler
        var getUserByIdQueryHandler = new GetUserByIdQueryHandler(); // Query Handler

        var createUserCommand = new CreateUserCommand("Azizur Rahman"); // Create Command
        createUserHandler.Handle(createUserCommand); // Create User using Handler

        var queryUserByIdCommand = new GetUserByIdQuery(1); // Query Command
        Console.WriteLine(getUserByIdQueryHandler.Handle(queryUserByIdCommand)); // Query User using Handler
    }
}
