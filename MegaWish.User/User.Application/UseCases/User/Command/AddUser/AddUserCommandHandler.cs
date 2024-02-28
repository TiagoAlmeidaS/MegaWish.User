using AutoMapper;
using MediatR;
using User.Application.Interfaces;
using User.Application.Services;
using User.Domain.Entities;
using User.Domain.Repositories;

namespace User.Application.UseCases.User.Command.AddUser;

public class AddUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<AddUserCommand, AddUserCommandResult>
{
    public async Task<AddUserCommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = mapper.Map<UserEntity>(request);
            await repository.Insert(user, cancellationToken);
            await unitOfWork.Commit(cancellationToken);

            return new AddUserCommandResult(user.Id, user.Name, user.Email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}