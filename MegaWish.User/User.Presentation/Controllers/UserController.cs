using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using User.Application.UseCases.User.Command.AddUser;
using User.Application.UseCases.User.Query.GetUser;

namespace User.Presentation.Controllers;

public class UserController(ISender mediator): BaseController
{
    [SwaggerOperation(Summary = "User", Description = "Create the user")]
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand query)
    {
        return await HandleRequestAsync(query, async async => await mediator.Send(query, CancellationToken.None));
    }
    
    [SwaggerOperation(Summary = "User", Description = "Get the user")]
    [HttpGet]
    public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query)
    {
        return await HandleRequestAsync(query, async async => await mediator.Send(query, CancellationToken.None));
    }
}