using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    internal class ProductCommentRepository : IProductCommentRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductComment> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ProductCommentRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductComment>();
        }

        public async Task<ProductComment> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? new ProductComment();
        }

        public async Task<ProductComment> GetByProductId(long productId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ProductId == productId) ?? new ProductComment();
        }

        public async Task<IEnumerable<ProductComment>> GetWithProduct()
        {
            var result = await DbSet.Include(x => x.ProductId).AsNoTracking().ToListAsync();
            return result;
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
