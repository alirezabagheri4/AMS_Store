using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CustomerDbContext _dbContext;
        protected readonly DbSet<Customer> _dbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Customer>();
        }

        public async Task<Customer> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id) ?? null;
        }

        public async Task<Customer> GetByNationalCode(string nationalCode)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.NationalCode == nationalCode)
                ?? new Customer();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result= await _dbSet.Include(x=>x.Address).AsNoTracking().ToListAsync();
            return result;
        }

        public void Add(Customer customer)
        {
            _dbSet.Add(customer);
        }

        public void Update(Customer customer)
        {
            _dbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            _dbSet.Remove(customer);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RemoveById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
