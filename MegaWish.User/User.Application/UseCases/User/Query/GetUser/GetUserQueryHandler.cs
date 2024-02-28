using AutoMapper;
using MediatR;
using User.Domain.Repositories;

namespace User.Application.UseCases.User.Query.GetUser;

public class GetUserQueryHandler(IUserRepository repository, IMapper mapper): IRequestHandler<GetUserQuery, GetUserResult>
{
    public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await repository.Get(request.Id, request.CustomerDocument, cancellationToken);
            var userMap = mapper.Map<GetUserResult>(user);
            return userMap;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}