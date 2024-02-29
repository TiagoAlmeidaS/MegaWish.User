using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;
using User.Domain.Repositories;

namespace User.Infra.Data.Repositories;

public class UserRepository(UserDBContext _context): IUserRepository
{
    private DbSet<UserEntity> _userDb => _context.Set<UserEntity>(); 
    
    public async Task Insert(UserEntity aggregate, CancellationToken cancellationToken) => await _userDb.AddAsync(aggregate, cancellationToken);

    public async Task<IList<UserEntity>> GetWhere(Expression<Func<UserEntity, bool>> predicate, CancellationToken cancellationToken) 
        => await _userDb.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);

    public async Task<UserEntity> Get(Guid id, CancellationToken cancellationToken) => 
        await _userDb.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken) ?? throw new Exception("User not found");
    public async Task<UserEntity> Get(Guid? id, string? customerDocument, CancellationToken cancellationToken) => 
        await _userDb.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id || e.CustomerDocument == customerDocument, cancellationToken) ?? throw new Exception("User not found");
}