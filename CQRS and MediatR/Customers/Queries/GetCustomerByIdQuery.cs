using MediatR;

public class GetCustomerByIdQuery : IRequest<string>
{
    public string Id { get; set; }

    public GetCustomerByIdQuery() { }
    public GetCustomerByIdQuery(string id)
    {
        Id = id;
    }
}