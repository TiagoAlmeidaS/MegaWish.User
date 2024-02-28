using User.Domain.Entities;
using User.Domain.SeedWork.GenericRepositories;

namespace User.Domain.Repositories;

public interface IUserRepository: IInsertRepository<UserEntity>, IGetWhereRepository<UserEntity>
{
}