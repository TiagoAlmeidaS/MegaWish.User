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
            var userEntity = new UserEntity(request.Name, request.Email, request.YearsOld, request.CustomerDocument, request.PhoneNumber);
            await repository.Insert(userEntity, cancellationToken);
            await unitOfWork.Commit(cancellationToken);

            return new AddUserCommandResult(userEntity.Id, userEntity.Name, userEntity.Email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}