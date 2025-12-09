╔══════════════════════════════════════╗   
║----------------@(CQRS + MediatR PATTERN)@----------------║   
╚══════════════════════════════════════╝
# Create an web api:
```
dotnet new webapi -n "CQRS with MediatR"
```

# install nuget package:
```
dotnet add package MediatR --version 14.0.0
```

# Add the MediatR dependency
```
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
```

# launchSettings.json
```
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "Customer",
      "applicationUrl": "http://localhost:5100",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
# Program.cs
```
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```

# Create folder for commands and queries
```
Controllers
    +-----> CustomerController
Customers
    |-----> Commands
    |          |------> CreateCustomerCommand
    |          |------> CreateCustomerCommandHandler
    +-----> Queries
               |------> GetCustomerByIdQuery
               |------> GetCustomerByIdQueryHandler
```

# create controller: Customer Controllers
```
using CQRS_with_MediatR.Customers.Commands;
using CQRS_with_MediatR.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_with_MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(string customerId)
        {
            var getCustomerByIdQuery = new GetCustomerByIdQuery() {
                Id = customerId
            };
            var response = await _mediator.Send(getCustomerByIdQuery);
            return Ok(response);
        }

        [HttpGet("{Id}/{Name}")]
        public async Task<IActionResult> Get(string Id, string Name)
        {
            var createCustomerCommand = new CreateCustomerCommand()
            {
                Id = Id,
                Name = Name
            };
            var response = await _mediator.Send(createCustomerCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Greet()
        {
            return Ok("Hello World");
        }
    }
}

```

# CreateCustomerCommand
```
using MediatR;

namespace CQRS_with_MediatR.Customers.Commands;

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
```
# CreateCustomerCommandHandler
```
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
```
# GetCustomerByIdQuery
```
using MediatR;

namespace CQRS_with_MediatR.Customers.Queries;

public class GetCustomerByIdQuery : IRequest<string>
{
    public string Id { get; set; }

    public GetCustomerByIdQuery() { }
    public GetCustomerByIdQuery(string id)
    {
        Id = id;
    }
}
```
# GetCustomerByIdQueryHandler
```
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
```
