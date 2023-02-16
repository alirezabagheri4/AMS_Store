using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Infra.Data.Persistence.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductGroup> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ProductGroupRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductGroup>();
        }

        public async Task<ProductGroup> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? new ProductGroup();
        }

        public Task<IEnumerable<ProductGroup>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGroup> GetByProductGroupName(string groupName)
        {
            return await DbSet.FirstOrDefaultAsync(x => EF.Functions.Like(x.GroupName, groupName)) ?? new ProductGroup();
        }

        public void Add(ProductGroup customer)
        {
            DbSet.Add(customer);
        }

        public void Update(ProductGroup customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(ProductGroup customer)
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
