using Domain.Common;

namespace Domain.Aggregates.ProductAggregate.Interfaces.IRepository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
