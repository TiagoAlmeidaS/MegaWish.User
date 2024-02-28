using User.Application.Interfaces;

namespace User.Infra.Data;

public class UnitOfWork(UserDBContext _context): IUnitOfWork
{
    public Task Commit(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);

    public Task Rollback(CancellationToken cancellationToken) =>
        _context.Database.RollbackTransactionAsync(cancellationToken);
}