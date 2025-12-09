using MediatR;

namespace CQRS_with_MediatR.Customers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
{
    public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(500);
        return $"create user successfully!\nuser id: {request.Id}\nuser name: {request.Name}";
    }
}