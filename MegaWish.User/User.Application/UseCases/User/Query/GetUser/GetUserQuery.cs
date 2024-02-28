using MediatR;

namespace User.Application.UseCases.User.Query.GetUser;

public class GetUserQuery: IRequest<GetUserResult>
{
    public Guid? Id { get; set; }
    public string? CustomerDocument { get; set; }
}