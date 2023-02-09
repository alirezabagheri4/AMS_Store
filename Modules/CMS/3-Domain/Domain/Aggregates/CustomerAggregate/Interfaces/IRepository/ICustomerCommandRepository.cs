using Domain.Aggregates.CustomerAggregate.Models;

namespace Domain.Aggregates.CustomerAggregate.Interfaces.IRepository
{
    public interface ICustomerCommandRepository : IRepository<Customer>
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        void RemoveById(long id);
    }
}
