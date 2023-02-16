using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Infra.Data.Persistence.Repository
{
    internal class ProductDescriptionRepository : IProductDescriptionRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductDescription> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ProductDescriptionRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductDescription>();
        }

        public async Task<ProductDescription> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? new ProductDescription();
        }

        public Task<IEnumerable<ProductDescription>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDescription> GetByProductId(long productId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ProductId == productId) ?? new ProductDescription();
        }

        public async Task<IEnumerable<ProductDescription>> GetWithProduct()
        {
            var result = await DbSet.Include(x => x.ProductId).AsNoTracking().ToListAsync();
            return result;
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
