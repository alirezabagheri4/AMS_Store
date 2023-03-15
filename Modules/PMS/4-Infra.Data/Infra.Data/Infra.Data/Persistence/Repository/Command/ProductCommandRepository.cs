using Domain.Aggregates.Product.Interfaces.IRepository.ICommand;
using Domain.Aggregates.Product.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Command
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<Product> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ProductCommandRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Product>();
        }

        public void Add(Product customer)
        {
            var result=DbSet.Add(customer);
        }

        public void Update(Product customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Product customer)
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
