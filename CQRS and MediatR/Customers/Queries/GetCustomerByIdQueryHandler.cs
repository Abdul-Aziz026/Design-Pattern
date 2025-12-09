using MediatR;

namespace CQRS_with_MediatR.Customers.Queries;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, string>
{
    public async Task<string> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.Delay(500);
        return $"return user id: {request.Id}";
    }
}