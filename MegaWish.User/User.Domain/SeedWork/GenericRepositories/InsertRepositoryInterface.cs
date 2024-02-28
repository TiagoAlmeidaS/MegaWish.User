namespace User.Domain.SeedWork.GenericRepositories;

public interface IInsertRepository<TAggregate> : IRepository
    where TAggregate : AggregateRoot
{
    public Task Insert(TAggregate aggregate, CancellationToken cancellationToken);
}