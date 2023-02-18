using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.Product.Interfaces.IRepository.ICommand;
using Domain.Aggregates.Product.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Command
{
    public class ProductDescriptionCommandRepository : IProductDescriptionCommandRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductDescription> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ProductDescriptionCommandRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductDescription>();
        }

        public void Add(ProductDescription customer)
        {
            DbSet.Add(customer);
        }

        public void Update(ProductDescription customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(ProductDescription customer)
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
