﻿using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
using Domain.Aggregates.Product.Models;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Aggregates.ProductComment.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Query
{
    public class ProductCommentQueryRepository : IProductCommentQueryRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductComment> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ProductCommentQueryRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductComment>();
        }

        public async Task<ProductComment> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ??  new ProductComment();
        }

        public async Task<IEnumerable<ProductComment>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ProductComment> GetByProductId(long productId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == productId) ?? new ProductComment();
        }

        public async Task<IEnumerable<ProductComment>> GetWithProduct()
        {
            var result = await DbSet.Include(x => x.Id).AsNoTracking().ToListAsync();
            return result;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
