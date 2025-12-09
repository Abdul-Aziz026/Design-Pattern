using MediatR;

public class CreateCustomerCommand : IRequest<string>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public CreateCustomerCommand() { }
    public CreateCustomerCommand(string id, string name)
    {
        Id = id;
        Name = name;
    }
}