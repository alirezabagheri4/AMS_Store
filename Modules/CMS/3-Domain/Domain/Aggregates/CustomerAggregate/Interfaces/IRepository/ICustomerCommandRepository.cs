﻿using Domain.Aggregates.CustomerAggregate.Models;

namespace Domain.Aggregates.CustomerAggregate.Interfaces.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        void RemoveById(long id);
    }
}
