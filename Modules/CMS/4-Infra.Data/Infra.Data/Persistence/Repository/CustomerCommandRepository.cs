using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    public class CustomerWRepository : ICustomerRepository
    {
        protected readonly CustomerDbContext DbContext;
        protected readonly DbSet<Customer> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CustomerWRepository(CustomerDbContext dbContext)
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

        //public async Task<Customer> GetById(long id)
        //{
        //    return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? null;
        //}

        //public async Task<Customer> GetByNationalCode(string nationalCode)
        //{
        //    return await DbSet.FirstOrDefaultAsync(x => x.NationalCode == nationalCode)
        //        ?? new Customer();
        //}

        //public async Task<IEnumerable<Customer>> GetAll()
        //{
        //    var result = await DbSet.Include(x => x.Address).AsNoTracking().ToListAsync();
        //    return result;
        //}
    }
}
