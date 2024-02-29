using AutoMapper;
using Grpc.Core;
using MediatR;
using User.Application.UseCases.User.Command.AddUser;
using User.Application.UseCases.User.Query.GetUser;

namespace User.Infra.GRPC.Services;

public class UserService(ILogger<UserService> _logger, ISender _mediator, IMapper mapper): GRPC.UserService.UserServiceBase
{
 
    public override async Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var query = new GetUserQuery()
        {
            Id = Guid.Parse(request.Id),
            CustomerDocument = request.CustomerDocument
        };
        
        var result = await _mediator.Send(query, context.CancellationToken);
        var response = new GetUserResponse()
        {
            Id = result.Id.ToString(),
            Name = result.Name,
            Email = result.Email
        };

        return response;
    }
    
    public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        var command = new AddUserCommand(request.Name, request.Email, (int)request.YearsOld, request.CostumerDocument, request.PhoneNumber);
        
        var result = await _mediator.Send(command, context.CancellationToken);
        var response = new CreateUserResponse()
        {
            Id = result.Id.ToString(),
            Name = result.Name,
            Email = result.Email
        };

        return response;
    }
}