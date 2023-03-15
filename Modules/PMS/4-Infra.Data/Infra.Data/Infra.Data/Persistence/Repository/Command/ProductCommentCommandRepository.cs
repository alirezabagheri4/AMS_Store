using Domain.Aggregates.ProductComment.Interface;
using Domain.Aggregates.ProductComment.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Command
{
    public class ProductCommentCommandRepository : IProductCommentCommandRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductComment> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ProductCommentCommandRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductComment>();
        }

        public void Add(ProductComment customer)
        {
            DbSet.Add(customer);
        }

        public void Update(ProductComment customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(ProductComment customer)
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
