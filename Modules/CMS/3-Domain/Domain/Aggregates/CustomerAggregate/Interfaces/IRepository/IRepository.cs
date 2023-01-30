﻿using Domain.Common;

namespace Domain.Aggregates.CustomerAggregate.Interfaces.IRepository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}