using User.Application.Services.Dto;
using User.Application.UseCases.User.Command.AddUser;
using User.Application.UseCases.User.Query.GetUser;

namespace User.Application.Services;

public interface IUserService
{
    public Task<GetUserResponse> GetUser(GetUserQuery query);
    public Task<AddUserResponse> AddUser(AddUserCommand command);
}