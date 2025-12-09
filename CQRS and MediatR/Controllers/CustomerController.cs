
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_with_MediatR.Controllers;

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
        var getCustomerByIdQuery = new GetCustomerByIdQuery()
        {
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