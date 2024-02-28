namespace User.Domain.SeedWork.GenericRepositories;

public interface IGetRepository<TAggregate> : IRepository
    where TAggregate : AggregateRoot
{
    public Task<TAggregate> Get(Guid id, CancellationToken cancellationToken);
    public Task<TAggregate> Get(Guid? id, string? customerDocument, CancellationToken cancellationToken);
}