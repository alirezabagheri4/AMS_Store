using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        protected readonly CustomerDbContext DbContext;
        protected readonly DbSet<Customer> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public CustomerCommandRepository(CustomerDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Customer>();
        }

        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void RemoveById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
